using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using WcfPersist.Persist;

namespace WcfPersist
{
    //SINGLE -> INSTANCIA UNICA e Sigle-Thread
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, 
        InstanceContextMode = InstanceContextMode.Single)]
    public class OrderInboundMessageHandlerService : IInboundMessageHandlerService
    {
		private Mongo mongo;

		public OrderInboundMessageHandlerService()
		{
			mongo = new Mongo();
		}

        [OperationBehavior()]
        public void ProcessIncomingMessage(MsmqMessage<string> mensagem)
        {
            Console.WriteLine("------------------------------------ mensagem recebida ---------------------------------------");

            var body = mensagem.Body;
			mongo.Insert(body);
			

            Console.WriteLine(body);
            Console.WriteLine();
        }
    }
}
