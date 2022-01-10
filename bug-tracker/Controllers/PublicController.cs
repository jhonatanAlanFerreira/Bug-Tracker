using System.Collections.Generic;
using System.Threading.Tasks;
using bug_tracker.Models;
using bug_tracker.Utils;
using Microsoft.AspNetCore.Mvc;

namespace bug_tracker.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicController
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        public PublicController(IUserRepository userRepository, IOrganizationRepository organizationRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
        }

        [HttpPost]
        [Route("organization")]
        public string createOrganization([FromBody] Organization organization)
        {
            Organization newOrganization = _organizationRepository.Create(organization);

            User newUser = new User
            {
                Name = "Administrador",
                Login = "Admin_" + RandomChars.RandomString(5),
                Email = newOrganization.Email,
                Password = RandomChars.RandomString(10),
                OrganizationId = newOrganization.Id,
                UserTypeId = 1
            };

            _userRepository.Create(newUser);

            var emailBindings = new Dictionary<string, string>();
            
            emailBindings.Add("organization", newOrganization.Name);
            emailBindings.Add("login", newUser.Login);
            emailBindings.Add("password", newUser.Password);

            SendEmail.send(newOrganization.Email, "Bug-Tracker - Informações de login", "organization-create", emailBindings);

            return "Cadastrado realizado com sucesso, as informações de acesso foram enviadas ao e-mail da organização.";
        }
    }

}