using System;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Common
{
    public static class ServiceProxyFactory
    {
        public static T Create<T>(string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            return (T)(new ServiceRealProxy<T>(endpointName).GetTransparentProxy());
        }
        public static T CreateDuplex<T>(InstanceContext context, string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            return (T)(new DuplexServiceRealProxy<T>(context, endpointName).GetTransparentProxy());
        }
    }
}
