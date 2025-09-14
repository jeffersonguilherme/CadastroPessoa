using CadastroPessoa.Models;
using CadastroPessoa.Models.Dtos.Responses;
using CadastroPessoa.Models.Dtos.Usuario.Request;

namespace CadastroPessoa.Services.Usuario;

public interface IUsuarioInterface
{
    Task<ResponseModel<UsuarioModel>> RegistarUsuario(UsuarioDto usuarioDto);
    Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios(int skip, int take);
}