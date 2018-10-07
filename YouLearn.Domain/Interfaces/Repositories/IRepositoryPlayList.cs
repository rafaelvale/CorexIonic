﻿using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayList
    {
        IEnumerable<PlayList> Listar(Guid idUsuario);

        PlayList Obter(Guid idPlayLit);

        PlayList Adicionar(PlayList playList);

        void Excluir(PlayList playList);
         
    }
}
