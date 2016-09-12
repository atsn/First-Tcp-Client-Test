using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace First_Tcp_Client_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream clientStream = null;
            try
            {


                string testtesttest = "messege";

                while (testtesttest.ToLower() != "stop")
                {
                    Console.WriteLine("write messege");
                    testtesttest = Console.ReadLine();

                    TcpClient client = new TcpClient("192.168.3.16", 6789);

                    clientStream = client.GetStream();

                    

                    StreamReader clientStreamReader = new StreamReader(clientStream);
                    StreamWriter clientStreamWriter = new StreamWriter(clientStream);
                    clientStreamWriter.AutoFlush = true;
                  

                    Console.Clear();

                    
                    clientStreamWriter.WriteLine(testtesttest);
                    Console.WriteLine("messege sent:  " + testtesttest);

                    string reshiedmessege = clientStreamReader.ReadLine();


                    Console.WriteLine("reshived messege:  " + reshiedmessege);

                    clientStream.Close();
                }

                Console.WriteLine("Press any key to shut down");
                Console.ReadKey();

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (clientStream != null)
                {
                    clientStream.Close();
                }
                
            }


        }
    }
}
