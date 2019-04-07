using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Messaging;
using System.Configuration;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace WcfMensagemRest
{
	// OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
	// OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
	public class WcfMensagemRest : IWcfMensagemRest
	{
		const string queueName = @".\Private$\trabalhofinal";

		public Stream SalvarMensagem(string mensagem)
		{
			MessageQueue mq = getQueue();
			mq.Send(mensagem);

			Dictionary<string, string> dict = new Dictionary<string, string>();
			dict.Add("result", "mensagem adicionada");

			return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dict)));
		}

		private MessageQueue getQueue()
		{
			MessageQueue mq;

			if (!MessageQueue.Exists(queueName))
			{
				MessageQueue.Create(queueName, false);
			}

			mq = new MessageQueue(queueName);
			return mq;
		}

	}
}
