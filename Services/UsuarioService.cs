﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Cadastrar(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            var resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário");
            }

        }

        public async Task Login(LoginUsuarioDto loginUsuarioDto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(loginUsuarioDto.Username, loginUsuarioDto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao autenticar usuário");
            }
        }
    }
}