using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryCanal
    {
        IEnumerable<Canal> Listar(Guid idUsuario);

        Canal Obter(Guid idCanal);

        Canal Adicionar(Canal canal);

        void Excluir(Canal canal);
         
    }
}
