using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DecideAi.Models;
using Microsoft.EntityFrameworkCore;



namespace DecideAi.Models
{
    public class StatusModel
    {

        public int StatusId { get; set; }

        public int UsuarioId { get; set; }

        public UsuarioModel? Usuario { get; set; }

        public string? EnderecoLocal { get; set; }

        public int Numero { get; set; }

        public int Cep { get; set; }

        public string? Bairro { get; set; }

        public string? Descricao { get; set; }

        public int MotivoId { get; set; }

        public MotivoModel? Motivo { get; set; }
    }
}