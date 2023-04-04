using System;
using AppBuscaCep.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace AppBuscaCep.Service
{
   public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/endereco/by-cep?cep=" + cep);
                
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return end;
           
        }
        public static async Task<List<Bairro>> GetBairrosByIdCidade(int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/bairro/by-cidade?id_cidade=" + arr_bairros);

                    if (response.IsSuccessStatusCode) 
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                    else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_bairros;
        }

        public static async Task<List<Logradouro>> GetLogradouroByBairroAndIdCidade(string bairro, int id_cidade)
        {
            List<Logradouro> arr_logradouro = new List<Logradouro>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/bairro/by-cidade?id_cidade" + id_cidade + "&bairro" + bairro);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    arr_logradouro = JsonConvert.DeserializeObject<List<Logradouro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_logradouro;
        }

        public static async Task<List<Cidade>> GetCidadeByUf(string UF)
        {
            List<Cidade> arr_cidade = new List<Cidade>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/cidade/by-uf?uf=" + UF);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    arr_cidade = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_cidade;
        }

        public static async Task<List<Cidade>> GetCidadesByEstado(string uf)
        {
            List<Cidade> arr_cidades = new List<Cidade>();  
            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/cidade/by-uf?uf=" + uf);
                if (response.IsSuccessStatusCode) 
                {
                    string json = response.Content.ReadAsStringAsync().Result;  

                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);   
                }
                else 
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_cidades;
        }

        public static async Task<List<Cep>> GetCepByLogradouro(string logradouro)
        {
            List<Cep> arr_cep = new List<Cep>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/cep/by-logradouro?logradouro=" + logradouro);
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cep = JsonConvert.DeserializeObject<List<Cep>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_cep;
        }






    }
}
