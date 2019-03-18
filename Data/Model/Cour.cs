using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Cour : ModelBase
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public Professeur Professeur { get; set; }
    }
}
