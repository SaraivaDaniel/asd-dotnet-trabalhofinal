using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace WebServices
{
	/// <summary>
	/// Descrição resumida de Mensagem
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
	// [System.Web.Script.Services.ScriptService]
	public class Mensagem : System.Web.Services.WebService
	{

		[WebMethod]
		public string Salvar(string mensagem)
		{

			try
			{
				HttpClient client = new HttpClient();

				dynamic json = new JObject();
				json.mensagem = mensagem;

				var endpoint = "http://localhost:8001/WcfMensagemRest.svc/SalvarMensagem";
				var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

				HttpResponseMessage response = client.PostAsync(endpoint, content).Result;

				if (response.IsSuccessStatusCode)
				{
					return "mensagem salva";
				}
				else
				{
					return "ocorreu um erro ao salvar a mensagem";
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
