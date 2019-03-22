using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamePipeStreamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.Out))
            {
                Console.WriteLine("NamedPipeServerStream object created.");

                // Wait for a client to connect
                Console.Write("Waiting for client connection...");
                pipeServer.WaitForConnection();

                Console.WriteLine("Client connected.");
                try
                {
                    // Read user input and send that to the client process.
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        while(true)
                        {
                            Console.Write("Enter text: ");
                            string readstring = Console.ReadLine();
                            if(readstring == "quit")
                            {
                                break;
                            }

                            sw.WriteLine(Console.ReadLine());
                        }
                        
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }
            }

        }
    }
}
