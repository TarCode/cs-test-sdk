﻿using System;
using System.Net;
using System.IO;

namespace hello
{
    class Pokemon {

        private string MakeRequest(string url) {
            WebRequest request = WebRequest.Create(url);

            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return responseFromServer;
        }

        public Object GetPokemon() {

            return MakeRequest("https://pokeapi.co/api/v2/pokemon/1");

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
