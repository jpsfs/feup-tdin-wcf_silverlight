﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:2.0.50727.5448
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="ServerOpsTcp")]
public interface ServerOpsTcp
{
    
    [System.ServiceModel.OperationContractAttribute(Action="urn:ServerOpsTcp/GetClients", ReplyAction="urn:ServerOpsTcp/GetClientsResponse")]
    string GetClients();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ServerOpsTcpChannel : ServerOpsTcp, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ServerOpsTcpClient : System.ServiceModel.ClientBase<ServerOpsTcp>, ServerOpsTcp
{
    
    public ServerOpsTcpClient()
    {
    }
    
    public ServerOpsTcpClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServerOpsTcpClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerOpsTcpClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerOpsTcpClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string GetClients()
    {
        return base.Channel.GetClients();
    }
}
