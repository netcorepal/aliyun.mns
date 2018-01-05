using System;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Util;
using System.Threading.Tasks;

namespace Aliyun.MNS.Runtime.Pipeline.Handlers
{
    /// <summary>
    /// This handler manages the metrics used to time the complete call and
    /// logs the final metrics.
    /// </summary>
    public class MetricsHandler : PipelineHandler
    {
        /// <summary>
        /// Captures the overall execution time and logs final metrics.
        /// </summary>
        /// <param name="executionContext">The execution context which contains both the
        /// requests and response context.</param>
        public override void InvokeSync(IExecutionContext executionContext)
        {
            InvokeAsync(executionContext).Wait();
        }

        
        public override async Task InvokeAsync(IExecutionContext executionContext)
        {
            executionContext.RequestContext.Metrics.AddProperty(Metric.AsyncCall, false);
            try
            {
                executionContext.RequestContext.Metrics.StartEvent(Metric.ClientExecuteTime);
                await base.InvokeAsync(executionContext).ConfigureAwait(false);
            }
            finally
            {
                executionContext.RequestContext.Metrics.StopEvent(Metric.ClientExecuteTime);
            }
        }

    }
}
