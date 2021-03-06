﻿using System;
using System.Collections.Generic;
using System.Net;
using Aliyun.MNS.Runtime.Internal.Util;
using Aliyun.MNS.Util;
using Aliyun.MNS.Runtime.Internal;
using System.Threading.Tasks;

namespace Aliyun.MNS.Runtime.Pipeline.ErrorHandler
{
    /// <summary>
    /// This handler processes exceptions thrown from the HTTP handler and
    /// unmarshalls error responses.
    /// </summary>
    public class ErrorHandler : PipelineHandler
    {
        /// <summary>
        /// Default set of exception handlers.
        /// </summary>
        private IDictionary<Type, IExceptionHandler> _exceptionHandlers;

        /// <summary>
        /// Default set of exception handlers.
        /// </summary>
        public IDictionary<Type, IExceptionHandler> ExceptionHandlers
        {
            get
            {
                return _exceptionHandlers;
            }
        }

        /// <summary>
        /// Constructor for ErrorHandler.
        /// </summary>
        public ErrorHandler()
        {
            _exceptionHandlers = new Dictionary<Type, IExceptionHandler>
            {
                {typeof(WebException), new WebExceptionHandler()},
                {typeof(HttpErrorResponseException), new HttpErrorResponseExceptionHandler()}
            };
        }

        /// <summary>
        /// Handles and processes any exception thrown from underlying handlers.
        /// </summary>
        /// <param name="executionContext">The execution context which contains both the
        /// requests and response context.</param>
        public override void InvokeSync(IExecutionContext executionContext)
        {
            InvokeAsync(executionContext).Wait();
        }

        public override async Task InvokeAsync(IExecutionContext executionContext)
        {
            try
            {
                await base.InvokeAsync(executionContext).ConfigureAwait(false);
                return;
            }
            catch (Exception exception)
            {
                DisposeReponse(executionContext.ResponseContext);
                bool rethrowOriginalException = ProcessException(executionContext, exception);
                if (rethrowOriginalException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Disposes the response body.
        /// </summary>
        /// <param name="responseContext">The response context.</param>
        private static void DisposeReponse(IResponseContext responseContext)
        {
            if (responseContext.HttpResponse != null &&
                responseContext.HttpResponse.ResponseBody != null)
            {
                responseContext.HttpResponse.ResponseBody.Dispose();
            }
        }

        /// <summary>
        /// Processes an exception by invoking a matching exception handler
        /// for the given exception.
        /// </summary>
        /// <param name="executionContext">The execution context, it contains the
        /// request and response context.</param>
        /// <param name="exception">The exception to be processed.</param>
        /// <returns>
        /// This method returns a boolean value which indicates if the original exception
        /// should be rethrown.
        /// This method can also throw a new exception that may be thrown by exception
        /// processing by a matching exception handler.
        /// </returns>
        private bool ProcessException(IExecutionContext executionContext, Exception exception)
        {
            executionContext.RequestContext.Metrics.AddProperty(Metric.Exception, exception);

            // Find the matching handler which can process the exception
            // Start by checking if there is a matching handler for the specific exception type,
            // if not check for handlers for it's base type till we find a match.
            var exceptionType = exception.GetType();
            var exceptionTypeInfo = TypeFactory.GetTypeInfo(exception.GetType());
            do
            {
                IExceptionHandler exceptionHandler = null;

                if (this.ExceptionHandlers.TryGetValue(exceptionType, out exceptionHandler))
                {
                    return exceptionHandler.Handle(executionContext, exception);
                }
                exceptionType = exceptionTypeInfo.BaseType;
                exceptionTypeInfo = TypeFactory.GetTypeInfo(exceptionTypeInfo.BaseType);

            } while (exceptionType != typeof(Exception));

            // No match found, rethrow the original exception.
            return true;
        }


    }
}
