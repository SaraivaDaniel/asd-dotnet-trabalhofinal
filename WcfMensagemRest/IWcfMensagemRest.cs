using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfMensagemRest
{
	// OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
	[ServiceContract]
	public interface IWcfMensagemRest
	{
		[OperationContract]
		[WebInvoke(
			Method = "POST",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, // com essa anotação, deve informar um JSON completo {"mensagem": "teste"}, caso contrário informar apenas string "teste"
			RequestFormat = WebMessageFormat.Json)]
		System.IO.Stream SalvarMensagem(string mensagem);
		
	}

}
