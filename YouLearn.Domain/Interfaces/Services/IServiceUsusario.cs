using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUsusario : IServiceBase
    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request);

        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request);
        
    }
}
