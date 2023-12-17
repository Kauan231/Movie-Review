using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Review.Data;
using Movie_Review.Data.Dtos;
using Movie_Review.Models;

namespace Movie_Review.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task SignUser(CreateUserDto dto)
        {
            User UserIdentity = _mapper.Map<User>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(UserIdentity, dto.Password);     

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        public async Task<string> Login(LoginUserDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var User = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(User);

            return token;

        }

        public async Task RemoveUser(RemoveUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserIdentityId);
            if(user == null) {
                throw new ApplicationException("Usuario não Existe");
            }
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao remover usuário!");
            }
        }
    }
}
