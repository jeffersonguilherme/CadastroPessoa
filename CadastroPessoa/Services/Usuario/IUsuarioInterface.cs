using CadastroPessoa.Models;
using CadastroPessoa.Models.Dtos.Login;
using CadastroPessoa.Models.Dtos.Responses;
using CadastroPessoa.Models.Dtos.Usuario.Request;

namespace CadastroPessoa.Services.Usuario;

public interface IUsuarioInterface
{
    Task<ResponseModel<UsuarioModel>> RegistarUsuario(UsuarioDto usuarioDto);
    Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios(int skip, int take);
    Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(Guid id);
    Task<ResponseModel<UsuarioModel>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto);
    Task<ResponseModel<UsuarioModel>> RemoveUsuario(Guid id);
    Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDto usuarioLoginDto);
}