
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;

        private User? _user;

        public AuthenticationService(IMapper mapper, ILoggerManager loggerManager, IConfiguration configuration, UserManager<User> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = loggerManager;
            _configuration = configuration;
        }

        public Task<string> CreateToken()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(UserForRegisterationDto userForRegisteration)
        {
            var user = _mapper.Map<User>(userForRegisteration);

            var result = await _userManager.CreateAsync(user, userForRegisteration.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userForRegisteration.Roles);

            return result;
        }


        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = _user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password);

            if (!result)
            {
                _logger.LogError($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");
            }

            return result;
        }

    }
}
