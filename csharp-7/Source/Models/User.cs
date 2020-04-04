using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        [MaxLength(100, ErrorMessage = "O campo deve ter at� 100 caracteres")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        [MaxLength(100, ErrorMessage = "O campo deve ter at� 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        [MaxLength(50, ErrorMessage = "O campo deve ter at� 50 caracteres")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        [MaxLength(255, ErrorMessage = "O campo deve ter at� 255 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo � obrigat�rio")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}