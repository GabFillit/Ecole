using Data.BusinessObject.DTO.ecole;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Ecole : ModelBase
    {
        public DateTime CreationDate { get; set; }

        public static Ecole From(EcoleCreateDto ecoleDto)
        {
            return new Ecole()
            {
                Name = ecoleDto.name,
                CreationDate = DateTime.Now
            };
        }
    }
}
