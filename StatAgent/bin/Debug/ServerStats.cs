﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IServerStats")]
public interface IServerStats
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerStats/getStats", ReplyAction="http://tempuri.org/IServerStats/getStatsResponse")]
    string getStats(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerStats/getStats", ReplyAction="http://tempuri.org/IServerStats/getStatsResponse")]
    System.Threading.Tasks.Task<string> getStatsAsync(int id);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServerStatsChannel : IServerStats, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ServerStatsClient : System.ServiceModel.ClientBase<IServerStats>, IServerStats
{
    
    public ServerStatsClient()
    {
    }
    
    public ServerStatsClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServerStatsClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerStatsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerStatsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string getStats(int id)
    {
        return base.Channel.getStats(id);
    }
    
    public System.Threading.Tasks.Task<string> getStatsAsync(int id)
    {
        return base.Channel.getStatsAsync(id);
    }
}
