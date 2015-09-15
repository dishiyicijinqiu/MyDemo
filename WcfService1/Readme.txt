IIS配置文件位置：C:\Windows\System32\inetsrv\config
IISExpress配置文件位置:D:\SZKL\Documents\IISExpress\config

WCF三要素，地址，绑定，契约
WCF 行为：IEndpointBehavior（节点行为），IServiceBehavior（服务行为），
IContractBehavior，（契约行为），IOperationBehavior（操作行为）

配置文件：
行为扩展：BehaviorExtensionElement

其他：ICallContextInitializer，IClientMessageInspector，IErrorHandler，IInstanceProvider


绑定：BasicHttpBinding,WSHttpBinding,WSDualHttpBinding,NetTcpBinding,NetMsmqBinding,NetPeerTcpBinding,MsmqIntegrationBinding,customBinding

绑定
配置元素
说明
BasicHttpBinding
一个绑定，适用于与符合WS-BasicProfile的Web服务（例如，基于ASP.NETWeb服务(ASMX)的服务）进行的通信。此绑定将HTTP用作传输协议，并将文本/XML用作默认消息编码。
WSHttpBinding
一个安全的、可互操作的绑定，适合于非双工服务协定。
WSDualHttpBinding
一个安全且可互操作的绑定，适用于双工服务协定或通过SOAP媒介进行的通信。
NetTcpBinding
一个安全且经过优化的绑定，适用于WCF应用程序之间跨计算机的通信。
NetNamedPipeBinding
一个安全、可靠且经过优化的绑定，适用于WCF应用程序之间计算机上的通信。
NetMsmqBinding
一个排队绑定，适用于WCF应用程序之间的跨计算机的通信。
NetPeerTcpBinding
一个启用安全的多计算机通信的绑定。
MsmqIntegrationBinding
一个适合于WCF应用程序和现有消息队列应用程序之间的跨计算机通信的绑定。
信道分发器（ChannelDispatcher），终结点分发器（EndpointDispatcher），消息分发器