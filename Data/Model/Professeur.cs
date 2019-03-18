using Data.BusinessObject.DTO.ecole;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Professeur : ModelBase
    {
        public Ecole Ecole { get; set; }

        public static Professeur From(ProfesseurCreateDto ProfesseurDto)
        {
            return new Professeur()
            {
                Name = ProfesseurDto.name,
            };
        }
    }
}
