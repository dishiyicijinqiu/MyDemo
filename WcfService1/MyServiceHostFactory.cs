using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading;
using System.Web;

namespace WcfService1
{
    public class MyServiceHostFactory : ServiceHostFactory
    {
        public override System.ServiceModel.ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            Thread.Sleep(5000);
            return base.CreateServiceHost(constructorString, baseAddresses);
        }
        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            Thread.Sleep(5000);
            var host = new UnityServiceHost(serviceType, baseAddresses);
            return host;
        }

    }
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }
        protected override void OnOpening()
        {
            base.OnOpening();
        }
        protected override void OnOpened()
        {
            base.OnOpened();
        }
        protected override void OnFaulted()
        {
            base.OnFaulted();
        }
    }
}