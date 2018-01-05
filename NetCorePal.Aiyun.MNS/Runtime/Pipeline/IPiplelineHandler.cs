using System;
using Aliyun.MNS.Runtime.Internal.Util;
using System.Threading.Tasks;

namespace Aliyun.MNS.Runtime.Pipeline
{
    /// <summary>
    /// Interface for a pipeline handler in a pipeline.
    /// </summary>
    public partial interface IPipelineHandler
    {
        /// <summary>
        /// The inner handler which is called after the current 
        /// handler completes it's processing.
        /// </summary>
        IPipelineHandler InnerHandler { get; set; }

        /// <summary>
        /// The outer handler which encapsulates the current handler.
        /// </summary>
        IPipelineHandler OuterHandler { get; set; }

        /// <summary>
        /// Contains the processing logic for a synchronous request invocation.
        /// This method should call InnerHandler.InvokeSync to continue processing of the
        /// request by the pipeline, unless it's a terminating handler.
        /// </summary>
        /// <param name="executionContext">The execution context which contains both the
        /// requests and response context.</param>
        void InvokeSync(IExecutionContext executionContext);


        Task InvokeAsync(IExecutionContext executionContext);
    }
}
