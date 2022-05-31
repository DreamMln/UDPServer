using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Server/Listener!");
            //User Datagram Protocol, UDP er en protokol til overførsel af data.
            //UDP er en del af Internet-protokolstakken.
            //UDP giver ingen garanti for at data kommer frem (eller rettere:
            //Afsenderen får ikke besked hvis data ikke kommer frem, ligeledes
            //får afsender ikke besked hvorvidt data er modtaget).

            //To create a server, the first thing you need to do is listen for
            //incoming messages. Client og Server skal kommunikere, det er det opgaven går ud på.
            //SERVEREN VIL GERNE MODTAGE/RECIEVE MESSAGES FRA CLIENT/SENDER

            //listen for incoming messages. In C# you do this by creating an UdpClient
            //and binding (listening) it to a specific network adapter and UDP port
            //initialize a using statement
            //The UdpClient class provides simple methods for sending and
            //receiving connectionless UDP in blocking synchronous mode.
            //connectionless transport protocol.
            using (UdpClient socket = new UdpClient())
            {
                //This only initializes the object binding it is done like:
                //This example “listens” on port 5005 on all network adapters
                //on the PC it is running.
                // initializes the object binding
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 5005));
                //IPEndPoint - contains the host and local or remote port information needed by
                //an application to connect to a service on a host. By combining
                //the host's IP address and port number of a service, the
                //IPEndPoint class forms a connection point to a service.
                IPEndPoint clientEndpoint = null;
                //byte array - A byte array is an array of bytes.
                //You could use a byte array to store a collection of binary data
                //One byte - det er 8 bits.One byte character sets can contain 255
                //characters.The current standard.
                byte[] dataReceived = socket.Receive(ref clientEndpoint);
                //object returned from the Receive function is a byte array.
                //Usually it is not interesting for us to simply view bytes,
                //we want it converted into a string.
                //Encoding - converting data into a format required for a number of
                //information processing needs - konverter til en string
                //Converts the bytes to a string using the UTF8 encoding,
                //the encoding method should be the same on client and server
                string messageSent = Encoding.UTF8.GetString(dataReceived);
                //message shown in the console
                Console.WriteLine("Message received from client: " + messageSent);
            }
        }
    }
}
