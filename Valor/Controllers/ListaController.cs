using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Valor.Controllers
{
    public class ListaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //Aguarda a resposta da função que chama a API
            dynamic teste = await PegarJson();
            ViewBag.Teste = teste;
            return View();
        }

        public static async Task<Lista> PegarJson()
        {

            HttpClient client = new HttpClient { BaseAddress = new Uri("https://brapi.dev/api/quote/list?limit=600") };
            var response = await client.GetAsync("");
            var content = await response.Content.ReadAsStringAsync();
            //Convert a resposta da API em um JSON
            dynamic lista = JsonConvert.DeserializeObject<Lista>(content);

            return lista;
        }
    }
}

