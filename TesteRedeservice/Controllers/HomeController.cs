using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteRedeservice.Models;
using TesteRedeservice.Services;
using TesteRedeservice.Services.Interfaces;
using System.IO;
using System.Text.Json;
using System.Net;

namespace TesteRedeservice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISeed _seed;
        private readonly IApiService _correiosService;

        public HomeController(ILogger<HomeController> logger, ISeed seed, IApiService correiosService)
        {
            _logger = logger;
            _seed = seed;
            _correiosService = correiosService;
        }

        public IActionResult Index()
        {
            var exercicios = _seed.MontarListaExercicios();
            var msg = ViewBag.Mensagem;
            ViewBag.ex = exercicios;
            return View();
        }

        public IActionResult Ex1()
        {
            return View();
        }

        public IActionResult Ex2(string numeros)
        {
            if (string.IsNullOrEmpty(numeros))
            {
                return RedirectToAction("Ex1");
            }
            else
            {
                var listaNumeros = numeros.Split(',').Select(int.Parse).ToList();
                ViewBag.listaNumeros = listaNumeros;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Ex2(string numerosLista, string stringNumeros)
        {
            try
            {
                stringNumeros = numerosLista.Remove((numerosLista.Length - 1), 1);//.Select(int.Parse).ToList();

                string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "numeros_ordenar.txt");

                string[] numeros = stringNumeros.Split(',');


                using (StreamWriter writer = new StreamWriter(caminhoArquivo))
                {
                    foreach (string numero in numeros)
                    {
                        writer.WriteLine(numero);
                    }
                }
                TempData["erro"] = "Arquivo gravado em: " + caminhoArquivo;
                return View();
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Erro ao gravar o arquivo: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Ex3()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ex3(List<clsTeste> listaCls)
        {
            for (int i = 1; i <= 100; i++)
            {
                clsTeste cls = new clsTeste()
                {
                    Codigo = i,
                    Descricao = DateTime.Now.ToString("yyyy / MM / dd HH:mm:ss.fff")
                };
                listaCls.Add(cls);
            }
            return View(listaCls);
        }
        public IActionResult Ex4(string cls)
        {
            try
            {
                var listaCls = JsonSerializer.Deserialize<List<clsTeste>>(cls);
                string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
                string listaJson = System.Text.Json.JsonSerializer.Serialize(listaCls);
                System.IO.File.WriteAllText(caminhoArquivo, listaJson);
                TempData["Resultado"] = "arquivo gravado com sucesso no caminho: " + caminhoArquivo;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Resultado"] = "Algo misterioso aconteceu e não foi possível gravar o arquivo. Err: " + ex;
                return View();
            }
        }

        public IActionResult Ex5()
        {
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "data.json");

            if (System.IO.File.Exists(caminhoArquivo))
            {
                string json = System.IO.File.ReadAllText(caminhoArquivo);
                List<clsTeste> listaCls = System.Text.Json.JsonSerializer.Deserialize<List<clsTeste>>(json);
                return View(listaCls);
            }
            return View();
        }

        public IActionResult Ex6()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ex6(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");
                var endereco = await _correiosService.ConsultaCorreio(cep);
                var enderecoFormatado = JsonSerializer.Deserialize<Endereco>(endereco);

                return View(enderecoFormatado);

            }
            catch (Exception)
            {
                
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Ex7()
        {

            var bancoJson = await _correiosService.ConsultaBanco();

            var teste = bancoJson.Length;
            var teste2 = bancoJson.Substring(0, teste);

            var bancos = JsonSerializer.Deserialize<List<Banco>>(bancoJson);

            return View(bancos);
        }

        public IActionResult Ex8()
        {
            string urlDaImagem = "https://redeservice.com.br/wp-content/uploads/2020/07/redeservice-logo.png";
            string pastaSistema = Directory.GetCurrentDirectory() + "/redeservice-logo.png";

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(urlDaImagem, pastaSistema);
            };

            byte[] bytes = System.IO.File.ReadAllBytes(pastaSistema);
            ViewBag.Base64 = Convert.ToBase64String(bytes);

            return View();
        }

    }
}