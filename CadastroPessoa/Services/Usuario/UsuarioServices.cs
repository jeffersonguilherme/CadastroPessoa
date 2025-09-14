using CadastroPessoa.Data;
using CadastroPessoa.Models;
using CadastroPessoa.Models.Dtos.Responses;
using CadastroPessoa.Models.Dtos.Usuario.Request;
using CadastroPessoa.Services.Senha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Services.Usuario;

public class UsuarioServices : IUsuarioInterface
{
    private readonly AppDbContext _context;
    private readonly ISenhaInterface _senhaInterface;
    public UsuarioServices(AppDbContext context, ISenhaInterface senhaInterface)
    {
        _context = context;
        _senhaInterface = senhaInterface;
    }

    public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios(int skip, int take)
    {
        ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
        try
        {
            var usuarios = await _context.Usuarios.Skip(skip).Take(take).ToListAsync();
            response.Dados = usuarios;
            response.Mensagem = "Usuários Localizados!";
            return response;
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<UsuarioModel>> RegistarUsuario(UsuarioDto usuarioDto)
    {
        ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
        try
        {
            if (!VerificaSeExisteEmailUsuario(usuarioDto))
            {
                response.Mensagem = "Email/Usuario já cadastrado!";
                response.Status = false;
                return response;
            }
            _senhaInterface.CriarSenhaHash(usuarioDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

            UsuarioModel usuario = new UsuarioModel()
            {
                Usuario = usuarioDto.Usuario,
                Email = usuarioDto.Email,
                Nome = usuarioDto.Nome,
                Sobrenome = usuarioDto.Sobrenome,
                DataNascimento = usuarioDto.DataNascimento,
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                SenhaHash = senhaHash,
                SenhaSalt = senhaSalt
            };
            _context.Add(usuario);
            await _context.SaveChangesAsync();

            response.Mensagem = "Usuário cadastrado com sucesso!";
            response.Dados = usuario;
            return response;

        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
    }
    private bool VerificaSeExisteEmailUsuario(UsuarioDto usuarioDto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(
            item => item.Email == usuarioDto.Email ||
                    item.Usuario == usuarioDto.Usuario);

        if (usuario != null)
        {
            return false;
        }
        return true;
    }

}