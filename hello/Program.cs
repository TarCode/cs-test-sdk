using System;
using System.Net;
using System.IO;

namespace hello
{
    class Pokemon {
        public Object GetPokemon() {
            WebRequest request = WebRequest.Create(
             "https://pokeapi.co/api/v2/pokemon/1");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

            // return content
            return responseFromServer;

            // Clean up the streams and the response.  

        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Pokemon p = new Pokemon();

            Console.WriteLine(p.GetPokemon());
        }
    }
}
