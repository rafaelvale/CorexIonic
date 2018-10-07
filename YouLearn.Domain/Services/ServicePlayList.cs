using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using prmToolkit.NotificationPattern.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resource;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServicePlayList : Notifiable, IServicePlayList
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryPlayList _repositoryPlayList;

        public ServicePlayList(IRepositoryUsuario repositoryUsuario, IRepositoryPlayList repositoryPlayList)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryPlayList = repositoryPlayList;
        }

        public PlayListResponse AdicionarPlayList(AdicionarPlayListRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            PlayList playList = new PlayList(request.Nome, usuario);

            AddNotifications(playList);

            if (this.IsInvalid()) return null;

            playList = _repositoryPlayList.Adicionar(playList);

            return (PlayListResponse)playList;

        }

        public Response ExcluirPlayList(Guid idPlayList)
        {
            // bool existe _respositoryVideo.ExistePlayListAssociado(idPlayList);
            bool existe = false;

            if(existe)
            {
                AddNotification("PlayList", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("PlayList", "Video"));
                return null;
            }

            PlayList playList = _repositoryPlayList.Obter(idPlayList);

            if (playList==null)
            {
                AddNotification("PlayList", MSG.DADOS_NAO_ENCONTRADOS);

            }
            if (this.IsInvalid()) return null;

            _repositoryPlayList.Excluir(playList);

            return new Response() { Message = MSG.OPERACAO_REAIZADA_COM_SUCESSO };
        }

        public IEnumerable<PlayListResponse> Listar(Guid idUsuario)
        {
            IEnumerable<PlayList> playListColection = _repositoryPlayList.Listar(idUsuario);

            var response = playListColection.ToList().Select(x => (PlayListResponse)x);

            return response;
        }
    }
}
