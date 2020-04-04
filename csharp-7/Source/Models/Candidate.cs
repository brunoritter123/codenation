using System;
using System.ComponentModel.DataAnnotations;

namespace Codenation.Challenge.Models
{
    public class Candidate
    {
        [Required(ErrorMessage = "Campo é obrigatório")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public int AccelerationId { get; set; }
        public Acceleration Acceleration { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}