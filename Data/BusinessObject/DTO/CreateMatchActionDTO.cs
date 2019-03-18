using System;
using System.Collections.Generic;
using System.Text;
using Data.Model.Enums;

namespace Data.BusinessObject.DTO
{
    public class CreateMatchActionDTO
    {
        public string LikedUserGuid { get; set; }
        public MatchActionStatus MatchActionStatus { get; set; }
    }
}
