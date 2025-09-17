using CadastroPessoa.Models.Dtos.Usuario.Request;
using CadastroPessoa.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioInterface _usuarioInterface;
    public LoginController(IUsuarioInterface usuarioInterface)
    {
        _usuarioInterface = usuarioInterface;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegistrarUsuairo(UsuarioDto usuarioDto) 
    {
        var usuario = await _usuarioInterface.RegistarUsuario(usuarioDto);
        return Ok(usuario);
    }

}