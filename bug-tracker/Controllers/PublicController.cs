using System;
using System.Collections.Generic;
using bug_tracker.Classes;
using bug_tracker.Models;
using bug_tracker.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;

namespace bug_tracker.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicController
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ILogRepository _logRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public PublicController(IUserRepository userRepository,
        IOrganizationRepository organizationRepository,
        IHttpContextAccessor contextAccessor,
        ILogRepository logRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _logRepository = logRepository;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        [Route("organization")]
        public RequestResponse createOrganization([FromBody] Organization organization)
        {
            Organization newOrganization = _organizationRepository.Create(organization);

            string password = RandomChars.RandomString(10);
            string bcryptPass = BCrypt.Net.BCrypt.HashPassword(password);

            User newUser = new User
            {
                Name = "Administrador",
                Login = "Admin_" + RandomChars.RandomString(5),
                Email = newOrganization.Email,
                Password = bcryptPass,
                OrganizationId = newOrganization.Id,
                UserTypeId = 1
            };

            _userRepository.Create(newUser);

            var emailBindings = new Dictionary<string, string>();

            emailBindings.Add("organization", newOrganization.Name);
            emailBindings.Add("login", newUser.Login);
            emailBindings.Add("password", password);

            SendEmail.send(newOrganization.Email, "Bug-Tracker - Informações de login", "organization-create", emailBindings);

            _logRepository.Create(new Log
            {
                LogTypeId = 1,
                OrganizationId = newOrganization.Id,
                Description = "Organização '" + newOrganization.Name + "' criada",
                Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                CreationDateTime = DateTime.Now
            });

            return new RequestResponse { Message = "Cadastro realizado com sucesso, as informações de acesso foram enviadas ao e-mail da organização." };
        }

        [HttpPost]
        [Route("user/login")]
        public RequestResponse userLogin([FromBody] UserLogin userLogin)
        {
            User user = _userRepository.GetByPassword(userLogin);
            if (user == null)
            {
                _logRepository.Create(new Log
                {
                    LogTypeId = 3,
                    Description = "Tentativa de login com dados inválidos",
                    Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    CreationDateTime = DateTime.Now
                });

                _contextAccessor.HttpContext.Response.StatusCode = 403;
                return new RequestResponse { Error = true, Message = "Login ou senha inválida" };
            }
            user.Token = TokenGenerate.GenerateToken(user);
            _userRepository.Update(user);

            _logRepository.Create(new Log
            {
                LogTypeId = 1,
                OrganizationId = user.OrganizationId,
                Description = "Usuário '" + user.Name + "' logou no sistema",
                Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                CreationDateTime = DateTime.Now
            });

            return new RequestResponse { Message = "Login efetuado com sucesso", Data = new { Token = user.Token } };
        }
    }

}