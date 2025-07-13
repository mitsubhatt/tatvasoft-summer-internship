using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mission.Entities.Models.MissionSkillModels;

namespace Mission.Repositories.IRepositories
{
    public interface IMissionSkillRepository
    {
        List<MissionSkillResponseModel> GetMissionSkillList();

        MissionSkillResponseModel GetMissionSkillById(int id);

        string AddMissionSkill(AddMissionSkillRequestModel model);

        string UpdateMissionSkill(UpdateMissionSkillRequestModel model);

        string DeleteMissionSkill(int id);
    }
}
