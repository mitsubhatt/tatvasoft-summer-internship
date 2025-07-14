using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Models.MissionsModels
{
    public class ApplyMissionRequestModel
    {
        public int UserId { get; set; }
        public int MissionId { get; set; }
        public DateTime AppliedDate { get; set; }
        public int Sheets { get; set; }
        public bool Status { get; set; }
    }
}
