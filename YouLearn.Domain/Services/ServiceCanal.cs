using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resource;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceCanal : Notifiable, IServiceCanal
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;

        public ServiceCanal(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public ServiceCanal(IRepositoryCanal repositoryCanal)
        {
            _repositoryCanal = repositoryCanal;
        }

        public CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            Canal canal = new Canal(request.Nome, request.UrlLogo, usuario);

            AddNotifications(canal);

            if (this.IsInvalid()) return null;

            canal = _repositoryCanal.Adicionar(canal);
            
            return (CanalResponse)canal;
            
        }

        public Response ExcluirCanal(Guid idCanal)
        {
            // bool existe _respositoryVideo.ExisteCanalAssociado(idCanal);
            bool existe = true;

            if (existe)
            {
                AddNotification("Canal", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("canal", "Video"));
                return null;
            }

            Canal canal = _repositoryCanal.Obter(idCanal);

            if (canal == null)
            {
                AddNotification("Canal", MSG.DADOS_NAO_ENCONTRADOS);

            }
            if (this.IsInvalid()) return null;

            _repositoryCanal.Excluir(canal);

            return new Response() { Message = MSG.OPERACAO_REAIZADA_COM_SUCESSO };
        }

        public IEnumerable<CanalResponse> Listar(Guid idUsuario)
        {
            IEnumerable<Canal> canalCollection = _repositoryCanal.Listar(idUsuario);

            var reponse = canalCollection.ToList().Select(entidade => (CanalResponse)entidade);

            return reponse;
        }
    }
}
