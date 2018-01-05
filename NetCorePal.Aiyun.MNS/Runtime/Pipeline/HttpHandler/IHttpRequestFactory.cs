using System;
using System.Collections.Generic;
using System.IO;
using Aliyun.MNS.Runtime.Internal.Transform;
using System.Threading.Tasks;

namespace Aliyun.MNS.Runtime.Pipeline.HttpHandler
{
    /// <summary>
    /// The interface for a HTTP request factory.
    /// </summary>
    /// <typeparam name="TRequestContent">The type used by the underlying HTTP API to represent the request body.</typeparam>
    public interface IHttpRequestFactory<TRequestContent> : IDisposable
    {
        /// <summary>
        /// Creates an HTTP request for the given URI.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>An HTTP request.</returns>
        IHttpRequest<TRequestContent> CreateHttpRequest(Uri requestUri);
    }

    /// <summary>
    /// The interface for an HTTP request that is agnostic of the underlying HTTP API.
    /// </summary>
    /// <typeparam name="TRequestContent">The type used by the underlying HTTP API to represent the HTTP request content.</typeparam>
    public interface IHttpRequest<TRequestContent> : IDisposable
    {
        /// <summary>
        /// The HTTP method or verb.
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// The request URI.
        /// </summary>
        Uri RequestUri { get; }

        /// <summary>
        /// Configures a request as per the request context.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        void ConfigureRequest(IRequestContext requestContext);

        /// <summary>
        /// Sets the headers on the request.
        /// </summary>
        /// <param name="headers">A dictionary of header names and values.</param>
        void SetRequestHeaders(IDictionary<string, string> headers);

        /// <summary>
        /// Gets a handle to the request content.
        /// </summary>
        /// <returns>The request content.</returns>
        TRequestContent GetRequestContent();

        Task<TRequestContent> GetRequestContentAsync();

        /// <summary>
        /// Returns the HTTP response.
        /// </summary>
        /// <returns>The HTTP response.</returns>
        IWebResponseData GetResponse();

        Task<IWebResponseData> GetResponseAsync();

        /// <summary>
        /// Writes a stream to the request body.
        /// </summary>
        /// <param name="requestContent">The destination where the content stream is written.</param>
        /// <param name="contentStream">The content stream to be written.</param>
        /// <param name="contentHeaders">HTTP content headers.</param>
        /// <param name="requestContext">The request context.</param>
        void WriteToRequestBody(TRequestContent requestContent, Stream contentStream, IDictionary<string,string> contentHeaders, IRequestContext requestContext);

        /// <summary>
        /// Writes a byte array to the request body.
        /// </summary>
        /// <param name="requestContent">The destination where the content stream is written.</param>
        /// <param name="content">The content stream to be written.</param>
        /// <param name="contentHeaders">HTTP content headers.</param>
        void WriteToRequestBody(TRequestContent requestContent, byte[] content, IDictionary<string,string> contentHeaders);
        
        /// <summary>
        /// Aborts the HTTP request.
        /// </summary>
        void Abort();

    }
}
