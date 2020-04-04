using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codenation.Challenge.Models
{
    public class Company
    {
        [Required(ErrorMessage = "Campo � obrigat�rio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        [MaxLength(100, ErrorMessage = "O campo deve ter at� 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        [MaxLength(50, ErrorMessage = "O campo deve ter at� 50 caracteres")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public ICollection<Candidate> Candidates { get; set; }

    }
}