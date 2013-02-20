using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServerOpsTcpClient client = new ServerOpsTcpClient();
            //ServerOpsHttpClient client = new ServerOpsHttpClient();

            Console.WriteLine(client.GetClients());
            Console.ReadLine();
            // Utilize a variável 'client' para chamar operações no serviço.

            // Fechar sempre o cliente.
            client.Close();
        }
    }
}
