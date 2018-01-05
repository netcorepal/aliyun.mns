using Aliyun.MNS.Runtime.Internal.Util;

namespace Aliyun.MNS.Runtime.Internal.Auth
{
    /// <summary>
    /// Interface for signing MNS request.
    /// </summary>
    public partial interface IServiceSigner
    {
         void Sign(IRequest request, RequestMetrics metrics, string accessKeyId, string secretAccessKey, string stsToken);
    }
}
