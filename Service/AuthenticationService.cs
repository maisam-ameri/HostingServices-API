
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Runtime.InteropServices.JavaScript;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IMapper mapper,ILoggerManager loggerManager,IConfiguration configuration,UserManager<User> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = loggerManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> RegisterUser(UserForRegisterationDto userForRegisteration)
        {
            var user = _mapper.Map<User>(userForRegisteration);

            var result = await _userManager.CreateAsync(user,userForRegisteration.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userForRegisteration.Roles);

            return result;
        }
    }
}
