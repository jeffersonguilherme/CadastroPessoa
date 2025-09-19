using CadastroPessoa.Models.Dtos.Usuario.Request;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarUsuarioPorId(Guid id)
    {
        var usuario = await _usuarioInterface.BuscarUsuarioPorId(id);
        return Ok(usuario);
    }

    [HttpPut]
    public async Task<IActionResult> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
    {
        var usuario = await _usuarioInterface.EditarUsuario(usuarioEdicaoDto);
        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveUsuario(Guid id)
    {
        var usuario = await _usuarioInterface.RemoveUsuario(id);
        return Ok(usuario);
    }
}