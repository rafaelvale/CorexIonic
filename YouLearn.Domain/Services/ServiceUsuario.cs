﻿using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resource;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsusario
    {

        //Dependencias do serviço de usuario
        private readonly IRepositoryUsuario _repositoryUsuario;

        //Construtor
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if(request == null)
            {
                AddNotification("AdicionarUsuarioRequest",MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
                return null;

            }
            
            //Cria objeto
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            Email email = new Email(request.Email);
            Usuario usuario = new Usuario(nome, email, request.Senha);
            
            AddNotifications(usuario);


            if (IsInvalid()) return null;

            //Persiste no banco de dados
            _repositoryUsuario.Salvar(usuario);
            
            
            return new AdicionarUsuarioResponse(usuario.Id);
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            if(request  == null)
            {
                AddNotification("AutenticarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AutenticarUsuarioRequest"));
                return null;
            }
            var email = new Email(request.Email);
            var usuario = new Usuario(email,request.Senha);


            AddNotifications(usuario);

            if (this.IsInvalid()) return null;

            usuario =   _repositoryUsuario.Obter(usuario.Email.Endereco, usuario.Senha);
            if(usuario == null)
            {
                AddNotification("Usuario", MSG.DADOS_NAO_ENCONTRADOS);

            }

            //var response = new AutenticarUsuarioResponse()
            //{
            //    Id = usuario.Id,
            //    PrimeiroNome = usuario.Nome.PrimeiroNome
            //};
            return (AutenticarUsuarioResponse)usuario;
        }
    }
}
