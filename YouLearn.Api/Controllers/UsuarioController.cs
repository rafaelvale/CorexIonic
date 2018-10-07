using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transaction;

namespace YouLearn.Api.Controllers
{
    public class UsuarioController : Base.ControllerBase
    {
        private readonly IServiceUsusario _serviceUsusario;

        public UsuarioController(IUnitOfWork unitOfWork, IServiceUsusario serviceUsusario) : base(unitOfWork)
        {
            _serviceUsusario = serviceUsusario;

        }



        //[AllowAnonymous]
        [HttpPost]
        [Route("api/v1/Usuario/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarUsuarioRequest request)
        {
            try
            {
                var response = _serviceUsusario.AdicionarUsuario(request);
                return await ResponseAsync(response, _serviceUsusario);

            }catch(Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }

        }
    }
}
