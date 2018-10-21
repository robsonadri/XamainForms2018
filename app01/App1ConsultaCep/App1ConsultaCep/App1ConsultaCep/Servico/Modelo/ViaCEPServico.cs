using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1ConsultaCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App1ConsultaCep.Servico.Modelo
{
    public class ViaCEPServico
    {
        // propiedade
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        // metodo
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            // variavel
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            // criar objeto
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if (end.cep==null) { return null; } 
            return end;
        }
    }
}
