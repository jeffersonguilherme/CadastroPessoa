using CadastroPessoa.Models.Dtos.Usuario.Request;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{


    [HttpPost("register")]
    public IActionResult RegistrarUsuairo(UsuarioDto usuarioDto) 
    {
        return Ok();
    }

}