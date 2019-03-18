using RemotableObjects;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;

namespace VulnerableDotNetHTTPRemotingClient
{
    class Client
    {
        static void Main(string[] args)
        {

            //String serverAddress = "http://localhost:1234/VulnerableEndpoint.rem";
            String serverAddress = "http://localhost:8080/VulnerableEndpoint.rem"; // to proxy them in Burp - redirecting it to localhost:1234 with "Support invisible proxying"

            /*
            // * The following code could not be used to secure the client application by setting the typeFilterLevel to Low:
            
            IDictionary props = new Hashtable();
            SoapClientFormatterSinkProvider clientProvider = new SoapClientFormatterSinkProvider();
            SoapServerFormatterSinkProvider serverProvider = new SoapServerFormatterSinkProvider()
            {
                TypeFilterLevel = TypeFilterLevel.Low // This is where we can exploit it without knowing anything about the application or having an 0day!
            };

            props["name"] = "ClientChannel";
            props["portName"] = Guid.NewGuid().ToString();
            props["typeFilterLevel"] = "Low";
            props["port"] = 0;

            HttpChannel clientChannel = new HttpChannel(props, clientProvider, serverProvider);

            // Register the channel.
            ChannelServices.RegisterChannel(clientChannel, false);

            RemotingConfiguration.RegisterWellKnownClientType(new WellKnownClientTypeEntry(typeof(RemoteObject1), serverAddress));
            
            // */

            RemoteObject1 obj1 = (RemoteObject1)Activator.GetObject(typeof(RemoteObject1), serverAddress);

            try
            {
                Console.WriteLine("Calling GetCount - received: {0}", obj1.GetCount());

                Console.WriteLine("Calling EchoMe - Received: {0}", obj1.EchoMe("This is my text for echo!"));

                Console.WriteLine("Calling GetCount - received: {0}", obj1.GetCount());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            /* Wait for the user prompt: */

            Console.WriteLine("Press ENTER to exit the client.");
            Console.ReadLine();
            Console.WriteLine("The client is exiting.");
        }
    }
}
