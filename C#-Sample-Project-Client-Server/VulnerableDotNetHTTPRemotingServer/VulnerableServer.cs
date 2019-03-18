using RemotableObjects;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;

namespace VulnerableDotNetHTTPRemotingServer
{
    class VulnerableServer
    {
        static void Main(string[] args)
        {

            /* Safe way of creating the channel without using SoapServerFormatterSinkProvider */
            //HttpServerChannel serverChannel = new HttpServerChannel(1234);
            /* Alternatively we could use this to create the server channel: */
            //HttpChannel serverChannel = new HttpChannel(1234);
            
            /* Instead if above, we want to create a vulnerable channel like this:  */
            /* start */
            
            SoapServerFormatterSinkProvider soapServerFormatterSinkProvider = new SoapServerFormatterSinkProvider()
            {
                TypeFilterLevel = TypeFilterLevel.Full // This is where we can exploit it without knowing anything about the application or having an 0day! Could be TypeFilterLevel.Low
            };

            IDictionary hashtables = new Hashtable();
            hashtables["port"] = 1234;
            hashtables["proxyName"] = null;
            hashtables["name"] = "Test Remoting Services";

            /* Creating the channel using SoapServerFormatterSinkProvider */
            HttpChannel serverChannel = new HttpChannel(hashtables, null, soapServerFormatterSinkProvider);
            /* Alternatively we could use this to create the server channel: */
            //HttpServerChannel serverChannel = new HttpServerChannel(hashtables, soapServerFormatterSinkProvider);
            
            /* end */

            /* the rest is shared between them all. */

            /* Register the server channel: */
            ChannelServices.RegisterChannel(serverChannel, false);

            /* Expose an object for remote calls: */
            /* This could also use WellKnownObjectMode.SingleCall instead of WellKnownObjectMode.Singleton */
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject1), "VulnerableEndpoint.rem", WellKnownObjectMode.Singleton);

            /* Wait for the user prompt: */
            Console.WriteLine("Press ENTER to exit the server.");
            Console.ReadLine();
            Console.WriteLine("The server is exiting.");
        }

    }

}
