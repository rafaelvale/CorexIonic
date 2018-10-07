using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {
        Usuario Obter(Guid Id);

        Usuario Obter(string email, string senha);

        void Salvar(Usuario usuario);

        bool Existe(string email);
    }
}
