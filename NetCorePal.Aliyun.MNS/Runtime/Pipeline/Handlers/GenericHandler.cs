using System;
using Aliyun.MNS.Runtime.Internal;
using System.Threading.Tasks;

namespace Aliyun.MNS.Runtime.Pipeline.Handlers
{    
    /// <summary>
    /// A generic handler that provides overridable PreInvoke and PostInvoke methods. 
    /// This class is intended be used as a base class for handlers which perform simple processing.
    /// </summary>
    public abstract class GenericHandler : PipelineHandler
    {
        /// <summary>
        /// Calls the PreInvoke and PostInvoke methods before and after calling the next handler 
        /// in the pipeline.
        /// </summary>
        /// <param name="executionContext">The execution context which contains both the
        /// requests and response context.</param>
        public override void InvokeSync(IExecutionContext executionContext)
        {
            InvokeAsync(executionContext).Wait();        
        }
        public override async Task InvokeAsync(IExecutionContext executionContext)
        {
            PreInvoke(executionContext);
            await base.InvokeAsync(executionContext).ConfigureAwait(false);
            PostInvoke(executionContext);
        }

        /// <summary>
        /// This method is invoked before calling the next handler in the pipeline.
        /// </summary>
        /// <param name="executionContext">The execution context, it contains the
        /// request and response context.</param>
        protected virtual void PreInvoke(IExecutionContext executionContext) { }

        /// <summary>
        /// This method is invoked after calling the next handler in the pipeline.
        /// </summary>
        /// <param name="executionContext">The execution context, it contains the
        /// request and response context.</param>
        protected virtual void PostInvoke(IExecutionContext executionContext) { }

       
    }
}
