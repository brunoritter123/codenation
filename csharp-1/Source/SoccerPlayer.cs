using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    class SoccerPlayer
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BirtDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }
        public bool Capitan { get; set; }

        public SoccerPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            Id = id;
            TeamId = teamId;
            Name = name;
            BirtDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
            Capitan = false;
        }
        
    }
}
