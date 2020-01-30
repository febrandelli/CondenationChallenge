using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Codenation
{
    class Program
    {              
        static async Task Main(string[] args)
        {
            Http http = new Http();
            Descodificacao descodificacao = new Descodificacao();
            Hash hash = new Hash(SHA1.Create());
            Arquivo arquivo = await http.GetApi();
            string fraseDescodificada = descodificacao.Descriptografa(arquivo.cifrado, arquivo.numero_casas);
            arquivo.decifrado = fraseDescodificada;
            string resumo = hash.GerarHash(fraseDescodificada);
            arquivo.resumo_criptografico = resumo;
            MultipartFormDataContent form = new MultipartFormDataContent();            
            //form.Add(new StringContent("Resumo"), resumo);

            string jsonToPost = JsonConvert.SerializeObject(arquivo);           
        }
    }
}
