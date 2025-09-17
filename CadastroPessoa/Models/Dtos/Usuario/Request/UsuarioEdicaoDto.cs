using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.Models.Dtos.Usuario.Request;

public class UsuarioEdicaoDto
{
    [Required(ErrorMessage = "Digite o Id do Usuário")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Digite o Usuário")]
    public string Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Digite o Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Digite o Sobrenome")]
    public string Sobrenome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Digite o Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Digite a Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

}