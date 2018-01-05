using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Transform;
using Aliyun.MNS.Runtime.Internal.Util;
using System.Threading.Tasks;

namespace Aliyun.MNS.Runtime.Pipeline.Handlers
{
    /// <summary>
    /// This handler unmarshalls the HTTP response.
    /// </summary>
    public class Unmarshaller : PipelineHandler
    {
        /// <summary>
        /// Unmarshalls the response returned by the HttpHandler.
        /// </summary>
        /// <param name="executionContext">The execution context which contains both the
        /// requests and response context.</param>
        public override void InvokeSync(IExecutionContext executionContext)
        {
            InvokeAsync(executionContext).Wait();
        }

        public override async Task InvokeAsync(IExecutionContext executionContext)
        {
            await base.InvokeAsync(executionContext).ConfigureAwait(false);

            if (executionContext.ResponseContext.HttpResponse.IsSuccessStatusCode)
            {
                // Unmarshall the http response.
                Unmarshall(executionContext);
            }
        }

        /// <summary>
        /// Unmarshalls the HTTP response.
        /// </summary>
        /// <param name="executionContext">
        /// The execution context, it contains the request and response context.
        /// </param>
        private void Unmarshall(IExecutionContext executionContext)
        {
            var requestContext = executionContext.RequestContext;
            var responseContext = executionContext.ResponseContext;

            try
            {
                var unmarshaller = requestContext.Unmarshaller;
                try
                {
                    requestContext.Metrics.StartEvent(Metric.ResponseProcessingTime);
                    var context = unmarshaller.CreateContext(responseContext.HttpResponse,
                            responseContext.HttpResponse.ResponseBody.OpenResponse(),
                            requestContext.Metrics);

                    var response = UnmarshallResponse(context, requestContext);
                    responseContext.Response = response;                    
                }
                finally
                {
                    if (!unmarshaller.HasStreamingProperty)
                        responseContext.HttpResponse.ResponseBody.Dispose();
                }
            }
            finally
            {
                requestContext.Metrics.StopEvent(Metric.ResponseProcessingTime);
            }
        }

        private WebServiceResponse UnmarshallResponse(UnmarshallerContext context,
            IRequestContext requestContext)
        {
            var unmarshaller = requestContext.Unmarshaller;
            WebServiceResponse response = null;
            try
            {
                requestContext.Metrics.StartEvent(Metric.ResponseUnmarshallTime);
                response = unmarshaller.UnmarshallResponse(context);
            }
            finally
            {
                requestContext.Metrics.StopEvent(Metric.ResponseUnmarshallTime);
            }

            requestContext.Metrics.AddProperty(Metric.StatusCode, response.HttpStatusCode);
            requestContext.Metrics.AddProperty(Metric.BytesProcessed, response.ContentLength);

            return response;
        }

    }
}
