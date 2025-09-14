using CadastroPessoa.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioInterface _usuarioInterface;
    public UsuarioController(IUsuarioInterface usuarioInterface)
    {
        _usuarioInterface = usuarioInterface;
    }

    [HttpGet]
    public async Task<IActionResult> ListarUsuarios(int skip = 0, int take = 20)
    {
        var usuarios = await _usuarioInterface.ListarUsuarios(skip, take);
        return Ok(usuarios);
    }
}