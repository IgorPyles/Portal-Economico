using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;

namespace Valor.Controllers
{
    public class StockController : Controller
    {
        public async Task<IActionResult> Index(string teste)
        {      

            //Aguarda a resposta da função que chama a API
            dynamic dados = await PegarJson1(teste);
            dynamic link = await PegarImagem();
            dynamic indica = await Indicadores(teste);
            ViewBag.Teste = dados;
            ViewBag.Imagem = link;
            ViewBag.Indica = indica;
            return View();
        }

        [HttpPost]
        static async Task<dynamic> PegarJson1(string stock)
        {

            HttpClient client = new HttpClient { BaseAddress = new Uri("https://mfinance.com.br/api/v1/stocks/") };
            var response = await client.GetAsync(stock);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(content);
        }

        [HttpPost]
        static async Task<dynamic> PegarImagem()
        {

            HttpClient client = new HttpClient { BaseAddress = new Uri("https://brapi.dev/api/quote/list?limit=600") };
            var response = await client.GetAsync("");
            var content = await response.Content.ReadAsStringAsync();

            //var lista = JsonConvert.DeserializeObject<Stock>(content);
            return  JsonConvert.DeserializeObject<Imagem>(content);
        }

        [HttpPost]
        static async Task<dynamic> Indicadores(string stock)
        {

            HttpClient client = new HttpClient { BaseAddress = new Uri("https://mfinance.com.br/api/v1/stocks/indicators/") };
            var response = await client.GetAsync(stock);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(content);
        }
    }
}
