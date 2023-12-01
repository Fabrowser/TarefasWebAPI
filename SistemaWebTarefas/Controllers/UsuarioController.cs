using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.ContentModel;
using SistemaWebTarefas.Models;
using System.Net;
using System.Text;
using Xunit;

namespace SistemaWebTarefas.Controllers
{
    public class UsuarioController : Controller
    {


        private readonly string ENDPOINT = "https://localhost:7162/api/Usuario/";

        private readonly HttpClient httpClient = null;


        public UsuarioController()
        {
            this.httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(ENDPOINT); 

        }

        public async Task<IActionResult> Index()
        {

            try
            {

                List<UsuarioViewModel> usuarios = null;

                HttpResponseMessage response = await httpClient.GetAsync(ENDPOINT);

                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    usuarios =  JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);

                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação!");
                }

                return View(usuarios);

            }
            
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

          
        }


        public async Task<IActionResult> Get(int id)
        {
            try
            {
                UsuarioViewModel result = await Pesquisar(id);
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome,Email")]UsuarioViewModel usuario)
        {
            try
            {
                string json = JsonConvert.SerializeObject(usuario);
                byte[] buffer  = Encoding.UTF8.GetBytes(json);
                ByteArrayContent byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                string url = ENDPOINT;
                HttpResponseMessage response = await httpClient.PostAsync(url, byteContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Erro ao processar a solcitação!");

                return RedirectToAction("Index"); 

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
           
                UsuarioViewModel usuario = await Pesquisar(id);
                return View(usuario);
        }

       
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Nome,Email")]UsuarioViewModel usuario)
        {
            try
            {

                string json = JsonConvert.SerializeObject(usuario);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var message = await httpClient.PutAsync(ENDPOINT, httpContent);
                return RedirectToAction("Index");




                /*string json = JsonConvert.SerializeObject(usuario);   
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                ByteArrayContent byteContent = new ByteArrayContent(buffer);    

                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                string url = ENDPOINT;  

                HttpResponseMessage response =  await httpClient.PutAsync(new Uri(ENDPOINT + usuario.Id), byteContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Erro ao processar a solicitação!");

                    return RedirectToAction("Index");*/



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        private async Task<UsuarioViewModel> Pesquisar(int id)
        {
            try
            {

                UsuarioViewModel result = null;

                string url  = $"{ENDPOINT}{id}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<UsuarioViewModel>(content);

                }   

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

    }
}
