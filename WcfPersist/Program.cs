using System;
using System.Messaging;
using System.ServiceModel;
using System.Threading;

namespace WcfPersist
{
    class Program
    {
        static ManualResetEvent signal = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            ////SELF-HOST (repare que não estou utilizando o IIS)
            using (var host = new ServiceHost(typeof(OrderInboundMessageHandlerService)))
            {
				host.Faulted += Faulted;
                host.Open();

                Console.WriteLine("Serviço iniciado ...");

                //Se apertar qualquer tecla vai sair do console
                Console.ReadLine();

                if (host != null)
                {
                    if (host.State == CommunicationState.Faulted)
                    {
                        host.Abort();
                    }
                    host.Close();
                }
            }
        }

        static void Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Problema no WCF. Aperte qualquer tecla para fechar.");
        }

      
    }
}
