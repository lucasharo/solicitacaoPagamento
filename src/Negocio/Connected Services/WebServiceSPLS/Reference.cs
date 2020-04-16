﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceSPLS
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://www.spls.com.br/", ItemName="string")]
    public class ArrayOfString : System.Collections.Generic.List<string>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.spls.com.br/", ConfigurationName="WebServiceSPLS.Sistema1Soap")]
    public interface Sistema1Soap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.spls.com.br/InserirDadosEDocumento", ReplyAction="*")]
        System.Threading.Tasks.Task<WebServiceSPLS.InserirDadosEDocumentoResponse> InserirDadosEDocumentoAsync(WebServiceSPLS.InserirDadosEDocumentoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.spls.com.br/AtualizarDados", ReplyAction="*")]
        System.Threading.Tasks.Task<WebServiceSPLS.AtualizarDadosResponse> AtualizarDadosAsync(WebServiceSPLS.AtualizarDadosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.spls.com.br/DeletarDados", ReplyAction="*")]
        System.Threading.Tasks.Task<WebServiceSPLS.DeletarDadosResponse> DeletarDadosAsync(WebServiceSPLS.DeletarDadosRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InserirDadosEDocumentoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InserirDadosEDocumento", Namespace="http://www.spls.com.br/", Order=0)]
        public WebServiceSPLS.InserirDadosEDocumentoRequestBody Body;
        
        public InserirDadosEDocumentoRequest()
        {
        }
        
        public InserirDadosEDocumentoRequest(WebServiceSPLS.InserirDadosEDocumentoRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.spls.com.br/")]
    public partial class InserirDadosEDocumentoRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string senha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string nomeDoCliente;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string dept;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string doc;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public byte[] arquivo;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string nomeDoArquivo;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public WebServiceSPLS.ArrayOfString metadadosC;
        
        public InserirDadosEDocumentoRequestBody()
        {
        }
        
        public InserirDadosEDocumentoRequestBody(string usuario, string senha, string nomeDoCliente, string dept, string doc, byte[] arquivo, string nomeDoArquivo, WebServiceSPLS.ArrayOfString metadadosC)
        {
            this.usuario = usuario;
            this.senha = senha;
            this.nomeDoCliente = nomeDoCliente;
            this.dept = dept;
            this.doc = doc;
            this.arquivo = arquivo;
            this.nomeDoArquivo = nomeDoArquivo;
            this.metadadosC = metadadosC;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InserirDadosEDocumentoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InserirDadosEDocumentoResponse", Namespace="http://www.spls.com.br/", Order=0)]
        public WebServiceSPLS.InserirDadosEDocumentoResponseBody Body;
        
        public InserirDadosEDocumentoResponse()
        {
        }
        
        public InserirDadosEDocumentoResponse(WebServiceSPLS.InserirDadosEDocumentoResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.spls.com.br/")]
    public partial class InserirDadosEDocumentoResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string InserirDadosEDocumentoResult;
        
        public InserirDadosEDocumentoResponseBody()
        {
        }
        
        public InserirDadosEDocumentoResponseBody(string InserirDadosEDocumentoResult)
        {
            this.InserirDadosEDocumentoResult = InserirDadosEDocumentoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AtualizarDadosRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AtualizarDados", Namespace="http://www.spls.com.br/", Order=0)]
        public WebServiceSPLS.AtualizarDadosRequestBody Body;
        
        public AtualizarDadosRequest()
        {
        }
        
        public AtualizarDadosRequest(WebServiceSPLS.AtualizarDadosRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.spls.com.br/")]
    public partial class AtualizarDadosRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string idVisual;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string senha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string nomeDoCliente;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public WebServiceSPLS.ArrayOfString metadadosC;
        
        public AtualizarDadosRequestBody()
        {
        }
        
        public AtualizarDadosRequestBody(string idVisual, string usuario, string senha, string nomeDoCliente, WebServiceSPLS.ArrayOfString metadadosC)
        {
            this.idVisual = idVisual;
            this.usuario = usuario;
            this.senha = senha;
            this.nomeDoCliente = nomeDoCliente;
            this.metadadosC = metadadosC;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AtualizarDadosResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AtualizarDadosResponse", Namespace="http://www.spls.com.br/", Order=0)]
        public WebServiceSPLS.AtualizarDadosResponseBody Body;
        
        public AtualizarDadosResponse()
        {
        }
        
        public AtualizarDadosResponse(WebServiceSPLS.AtualizarDadosResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.spls.com.br/")]
    public partial class AtualizarDadosResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string AtualizarDadosResult;
        
        public AtualizarDadosResponseBody()
        {
        }
        
        public AtualizarDadosResponseBody(string AtualizarDadosResult)
        {
            this.AtualizarDadosResult = AtualizarDadosResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeletarDadosRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DeletarDados", Namespace="http://www.spls.com.br/", Order=0)]
        public WebServiceSPLS.DeletarDadosRequestBody Body;
        
        public DeletarDadosRequest()
        {
        }
        
        public DeletarDadosRequest(WebServiceSPLS.DeletarDadosRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.spls.com.br/")]
    public partial class DeletarDadosRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string idVisual;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string senha;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string nomeDoCliente;
        
        public DeletarDadosRequestBody()
        {
        }
        
        public DeletarDadosRequestBody(string idVisual, string usuario, string senha, string nomeDoCliente)
        {
            this.idVisual = idVisual;
            this.usuario = usuario;
            this.senha = senha;
            this.nomeDoCliente = nomeDoCliente;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeletarDadosResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DeletarDadosResponse", Namespace="http://www.spls.com.br/", Order=0)]
        public WebServiceSPLS.DeletarDadosResponseBody Body;
        
        public DeletarDadosResponse()
        {
        }
        
        public DeletarDadosResponse(WebServiceSPLS.DeletarDadosResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.spls.com.br/")]
    public partial class DeletarDadosResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string DeletarDadosResult;
        
        public DeletarDadosResponseBody()
        {
        }
        
        public DeletarDadosResponseBody(string DeletarDadosResult)
        {
            this.DeletarDadosResult = DeletarDadosResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public interface Sistema1SoapChannel : WebServiceSPLS.Sistema1Soap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public partial class Sistema1SoapClient : System.ServiceModel.ClientBase<WebServiceSPLS.Sistema1Soap>, WebServiceSPLS.Sistema1Soap
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public Sistema1SoapClient(EndpointConfiguration endpointConfiguration) : 
                base(Sistema1SoapClient.GetBindingForEndpoint(endpointConfiguration), Sistema1SoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Sistema1SoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(Sistema1SoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Sistema1SoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(Sistema1SoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Sistema1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceSPLS.InserirDadosEDocumentoResponse> WebServiceSPLS.Sistema1Soap.InserirDadosEDocumentoAsync(WebServiceSPLS.InserirDadosEDocumentoRequest request)
        {
            return base.Channel.InserirDadosEDocumentoAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceSPLS.InserirDadosEDocumentoResponse> InserirDadosEDocumentoAsync(string usuario, string senha, string nomeDoCliente, string dept, string doc, byte[] arquivo, string nomeDoArquivo, WebServiceSPLS.ArrayOfString metadadosC)
        {
            WebServiceSPLS.InserirDadosEDocumentoRequest inValue = new WebServiceSPLS.InserirDadosEDocumentoRequest();
            inValue.Body = new WebServiceSPLS.InserirDadosEDocumentoRequestBody();
            inValue.Body.usuario = usuario;
            inValue.Body.senha = senha;
            inValue.Body.nomeDoCliente = nomeDoCliente;
            inValue.Body.dept = dept;
            inValue.Body.doc = doc;
            inValue.Body.arquivo = arquivo;
            inValue.Body.nomeDoArquivo = nomeDoArquivo;
            inValue.Body.metadadosC = metadadosC;
            return ((WebServiceSPLS.Sistema1Soap)(this)).InserirDadosEDocumentoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceSPLS.AtualizarDadosResponse> WebServiceSPLS.Sistema1Soap.AtualizarDadosAsync(WebServiceSPLS.AtualizarDadosRequest request)
        {
            return base.Channel.AtualizarDadosAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceSPLS.AtualizarDadosResponse> AtualizarDadosAsync(string idVisual, string usuario, string senha, string nomeDoCliente, WebServiceSPLS.ArrayOfString metadadosC)
        {
            WebServiceSPLS.AtualizarDadosRequest inValue = new WebServiceSPLS.AtualizarDadosRequest();
            inValue.Body = new WebServiceSPLS.AtualizarDadosRequestBody();
            inValue.Body.idVisual = idVisual;
            inValue.Body.usuario = usuario;
            inValue.Body.senha = senha;
            inValue.Body.nomeDoCliente = nomeDoCliente;
            inValue.Body.metadadosC = metadadosC;
            return ((WebServiceSPLS.Sistema1Soap)(this)).AtualizarDadosAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceSPLS.DeletarDadosResponse> WebServiceSPLS.Sistema1Soap.DeletarDadosAsync(WebServiceSPLS.DeletarDadosRequest request)
        {
            return base.Channel.DeletarDadosAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceSPLS.DeletarDadosResponse> DeletarDadosAsync(string idVisual, string usuario, string senha, string nomeDoCliente)
        {
            WebServiceSPLS.DeletarDadosRequest inValue = new WebServiceSPLS.DeletarDadosRequest();
            inValue.Body = new WebServiceSPLS.DeletarDadosRequestBody();
            inValue.Body.idVisual = idVisual;
            inValue.Body.usuario = usuario;
            inValue.Body.senha = senha;
            inValue.Body.nomeDoCliente = nomeDoCliente;
            return ((WebServiceSPLS.Sistema1Soap)(this)).DeletarDadosAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.Sistema1Soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.Sistema1Soap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.Sistema1Soap))
            {
                return new System.ServiceModel.EndpointAddress("http://sistemas.spls.com.br/wsuploadfile/sistema1.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.Sistema1Soap12))
            {
                return new System.ServiceModel.EndpointAddress("http://sistemas.spls.com.br/wsuploadfile/sistema1.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            Sistema1Soap,
            
            Sistema1Soap12,
        }
    }
}
