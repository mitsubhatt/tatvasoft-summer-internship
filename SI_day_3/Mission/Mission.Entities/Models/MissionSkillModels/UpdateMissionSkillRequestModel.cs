using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Models.MissionSkillModels
{
    public class UpdateMissionSkillRequestModel : AddMissionSkillRequestModel
    {
        public int Id { get; set; }
    }
}
