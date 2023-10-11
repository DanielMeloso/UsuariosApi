using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            await _usuarioService.Cadastrar(usuarioDto);

            return Ok("Usuário cadastrado com sucesso");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto loginUsuarioDto)
        {
            await _usuarioService.Login(loginUsuarioDto);
            return Ok("Usuário autenticado");

        }
    }
}
