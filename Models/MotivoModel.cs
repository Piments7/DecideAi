using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace DecideAi.Models
{
    public class MotivoModel
    {
        public int MotivoId { get; set; }

        public string? Motivo { get; set; }

        public string? Buraco { get; set; }

        public string? ILuminacaoPublica { get; set; }

        public string? LixoNaoColetado { get; set; }

        public string? Outros { get; set; }
    }
}