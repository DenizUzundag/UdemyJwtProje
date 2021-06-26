using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YSKProje.UdemyJwtProje.Entities.Dtos.AppUserDtos;
using YSKProje.UdemyJwtProje.Entities.Token;

namespace YSK.UdemyJwtProje.WebApi.Controllers.Account
{

    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto appuserLoginDto)
        {
            if(ModelState.IsValid)
            {


                string jsonData= JsonConvert.SerializeObject(appuserLoginDto);
                var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");

                using var httpClient = new HttpClient();
               var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/Auth/SignIn", stringContent);

                if(responseMessage.IsSuccessStatusCode)
                {
                    var token = JsonConvert.DeserializeObject<JwtAccessToken>(await responseMessage.Content.ReadAsStringAsync());
                    _httpContextAccessor.HttpContext.Session.SetString("token", token.Token);
                }

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Api'Hatası");
                return View(appuserLoginDto);

            }
          
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("SignIn", "Home");
        }
    }
}
