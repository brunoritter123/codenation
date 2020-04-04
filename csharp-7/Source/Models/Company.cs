using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codenation.Challenge.Models
{
    public class Company
    {
        [Required(ErrorMessage = "Campo é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo deve ter até 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo deve ter até 50 caracteres")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public ICollection<Candidate> Candidates { get; set; }

    }
}