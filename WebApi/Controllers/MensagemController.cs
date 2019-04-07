using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {

		[HttpPost]
		public string Salvar([FromBody]  MensagemInfo mensagemInfo)
		{
			try
			{
				HttpClient client = new HttpClient();

				dynamic mensagem = new JObject();
				mensagem.mensagem = mensagemInfo.mensagem;

				var endpoint = "http://localhost:8001/WcfMensagemRest.svc/SalvarMensagem";
				var content = new StringContent(mensagem.ToString(), Encoding.UTF8, "application/json");
				
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