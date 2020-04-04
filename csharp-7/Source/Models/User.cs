using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo deve ter até 100 caracteres")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo deve ter até 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo deve ter até 50 caracteres")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "O campo deve ter até 255 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}