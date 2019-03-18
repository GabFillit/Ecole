using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Eleve : ModelBase
    {
        public Ecole Ecole { get; set; }
        public List<Cour> Cours { get; set; }
    }
}
