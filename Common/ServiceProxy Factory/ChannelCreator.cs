using System;
using System.Collections;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Common
{
    internal static class ChannelFactoryCreator
    {
        private static Hashtable channelFactories = new Hashtable();

        public static ChannelFactory<T> Create<T>(string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }

            ChannelFactory<T> channelFactory = null;

            if (channelFactories.ContainsKey(endpointName))
            {
                channelFactory = channelFactories[endpointName] as ChannelFactory<T>;
            }

            if (channelFactory == null)
            {
                channelFactory = new ChannelFactory<T>(endpointName);
                lock (channelFactories.SyncRoot)
                {
                    channelFactories[endpointName] = channelFactory;
                }
            }

            return channelFactory;
        }
        public static DuplexChannelFactory<T> CreateDuplex<T>(InstanceContext context, string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            var key = new DuplexKey(context, endpointName);
            DuplexChannelFactory<T> channelFactory = null;
            if (channelFactories.ContainsKey(key))
            {
                channelFactory = channelFactories[key] as DuplexChannelFactory<T>;
            }
            if (channelFactory == null)
            {
                channelFactory = new DuplexChannelFactory<T>(context, endpointName);
                lock (channelFactories.SyncRoot)
                {
                    channelFactories[key] = channelFactory;
                }
            }

            return channelFactory;
        }
        public class DuplexKey
        {
            public DuplexKey(InstanceContext instancecontext, string endpointname)
            {
                InstanceContext = instancecontext;
                EndpointName = endpointname;
            }
            public string EndpointName { get; set; }
            public InstanceContext InstanceContext { get; set; }
            public override bool Equals(object obj)
            {
                var key = obj as DuplexKey;
                if (key == null)
                    return false;
                return (this.EndpointName == key.EndpointName && key.InstanceContext == this.InstanceContext);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}