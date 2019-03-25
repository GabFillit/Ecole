using Data.BusinessObject.DTO.eleve;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Eleve : ModelBase
    {
        public Ecole Ecole { get; set; }

        public static Eleve From(EleveCreateDto eleveDto)
        {
            return new Eleve()
            {
                Name = eleveDto.name,
            };
        }
    }
}
