using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YouLearn.Api.Controllers
{
    public class UtilController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Seja bem vindo ao YouLearn";
        }

        [HttpGet]
        [Route("Versao")]
        public string Versao()
        {
            return "Versao: 0.0.1";
        }
    }
}