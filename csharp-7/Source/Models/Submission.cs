using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    public class Submission
    {
        [Required(ErrorMessage = "Campo é obrigatório")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public int ChallengeId { get; set; }
        public Challenge Challenges { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public decimal Score { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}