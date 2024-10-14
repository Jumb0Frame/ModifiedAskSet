using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jotunn.Configs;

namespace ModifiedAskSet
{
    internal class RecipeConfig
    {
        private string craftStation;
        private string repairStation;
        private int stationLvl;
        private RequirementConfig requirementConfig1;
        private RequirementConfig requirementConfig2;
        private RequirementConfig requirementConfig3;
        private RequirementConfig requirementConfig4;

        public RecipeConfig(string _craft, string _repair, int _stationLvl, RequirementConfig _req1, RequirementConfig _req2, RequirementConfig _req3, RequirementConfig _req4) 
        { 
            craftStation = _craft;
            repairStation = _repair;
            stationLvl = _stationLvl;

            //todo check that the requirements aren't null

            requirementConfig1 = _req1;
            requirementConfig2 = _req2;
            requirementConfig3 = _req3;
            requirementConfig4 = _req4;
        }

        //todo more stuff ?
    }
}
