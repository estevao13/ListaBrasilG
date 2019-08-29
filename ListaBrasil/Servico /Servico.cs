using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using ListaBrasil.Modelo;
using Newtonsoft.Json;
using System.IO;

namespace ListaBrasil.Servico
{
    public class Servico
    {
        private static string URLEstado = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
        private static string URLMunicipio = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";


        public static List<Estado> GetEstados()
        {
            string conteudo = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URLEstado);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                conteudo = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Estado>>(conteudo);
        }

        public static List<Municipio> GetMunicipios(int estado)
        {

            string conteudo = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URLMunicipio);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                conteudo = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Municipio>>(conteudo);

            //string newURL = string.Format(URLMunicipio, estado);
            //WebClient wc = new WebClient();
            //string conteudo = wc.DownloadString(newURL);
            //return JsonConvert.DeserializeObject<List<Municipio>>(conteudo);
        }
    }
}
