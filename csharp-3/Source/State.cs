using System;

namespace Codenation.Challenge
{
    public class State
    {
        public State(string name, string acronym, double areaKM = 0)
        {
            this.Name = name;
            this.Acronym = acronym;
            this.AreaKM = areaKM;
        }

        public string Name { get; set; }

        public string Acronym { get; set; }
        public double AreaKM { get; set; }

    }

}
