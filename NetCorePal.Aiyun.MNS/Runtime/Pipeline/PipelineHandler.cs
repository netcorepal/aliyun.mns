using System;
using Aliyun.MNS.Runtime.Internal;
using Aliyun.MNS.Runtime.Internal.Util;
using System.Threading.Tasks;

namespace Aliyun.MNS.Runtime.Pipeline
{
    /// <summary>
    /// An abstract pipeline handler that has implements IPipelineHandler,
    /// and has the default implmentation. This is the base class for most of
    /// the handler implementations.
    /// </summary>
    public abstract partial class PipelineHandler : IPipelineHandler
    {
        /// <summary>
        /// The inner handler which is called after the current 
        /// handler completes it's processing.
        /// </summary>
        public IPipelineHandler InnerHandler { get; set; }

        /// <summary>
        /// The outer handler which encapsulates the current handler.
        /// </summary>
        public IPipelineHandler OuterHandler { get; set; }

        /// <summary>
        /// Contains the processing logic for a synchronous request invocation.
        /// This method calls InnerHandler.InvokeSync to continue processing of the
        /// request by the pipeline.
        /// </summary>
        /// <param name="executionContext">The execution context which contains both the
        /// requests and response context.</param>
        public virtual void InvokeSync(IExecutionContext executionContext)
        {
            InvokeAsync(executionContext).Wait();   
        }

        public virtual async Task InvokeAsync(IExecutionContext executionContext)
        {
            if (this.InnerHandler != null)
            {
                await InnerHandler.InvokeAsync(executionContext).ConfigureAwait(false);
                return;
            }
            throw new InvalidOperationException("Cannot invoke InnerHandler. InnerHandler is not set.");
        }
    }
}
