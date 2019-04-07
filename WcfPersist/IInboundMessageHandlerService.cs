using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

namespace WcfPersist
{
	[ServiceKnownType(typeof(string))]
	[ServiceContract]
	public interface IInboundMessageHandlerService
	{
		[OperationContract(IsOneWay = true, Action = "*")]
		void ProcessIncomingMessage(MsmqMessage<string> mensagem);
	}
}
