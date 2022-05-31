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
            //UDP er en del af Internet-protokolstakken. Og giver ingen garanti for at data kommer frem (eller rettere:
            //Afsenderen får ikke besked hvis data ikke kommer frem, ligeledes
            //får afsender ikke besked hvorvidt data er modtaget).

            //Client og Server skal kommunikere, det er det opgaven går ud på.
            //SERVEREN VIL GERNE MODTAGE/RECIEVE MESSAGES FRA EN CLIENT/SENDER (LYTTE/LISTENER TIL INDKOMMENDE MESSAGES)

            //LYTTE til indkommende messages. I C# gæres dette ved at create/oprette en UdpClient
            //og bruge binding (listening) det til et specik netværk adapter samt en UDP port
            //først initialiseres et using statement
            //UdpClient class - har nogle metoder der bruges til at sende
            //modtage connectionless UDP. det er en transport protocol.

            using (UdpClient socket = new UdpClient())
            {
                //Her/lytter “listens” der på port 5005, på alle netværks adapters
                //på den PC det køres.
                // her initialiseres object binding:
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 5005));
                //IPEndPoint - indeholder en host og en local eller remote port, som er den information der behøves
                //for at få en application til at connecte til en service på en host. ved at kombinere
                // hosten's IP address og port-nummer på en service, tager
                //IPEndPoint class og opretter et connection point til den service.
                IPEndPoint clientEndpoint = null;
                //byte array - et byte array er et array med/af bytes.
                //det kan bruges til at have en collection af binary data
                //En byte - er 8 bits. En byte character sæt kan indeholde 0-255
                //characters.
                //modtager fra en client
                byte[] dataReceived = socket.Receive(ref clientEndpoint);
                //object returned from the Receive function is a byte array.
                //Usually it is not interesting for us to simply view bytes,
                //we want it converted into a string.
                //Encoding - converting data into a format required for a number of
                //information processing needs - konverter til en string
                //Converts the bytes to a string using the UTF8 encoding,
                //the encoding method should be the same on client and server
                //Encoding - konvertere det til en string
                //UTF8 - beskederne sendes i UTF8 format
                string messageSent = Encoding.UTF8.GetString(dataReceived);
                //message shown in the console
                Console.WriteLine("Message received from client: " + messageSent);
            }
        }
    }
}
