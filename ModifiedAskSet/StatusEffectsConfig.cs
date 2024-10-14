using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedAskSet
{
    internal class StatusEffectsConfig
    {
        private string unityEffectsName;
        private string name;
        private string tooltip;

        //raise skills
        private Skills.SkillType m_raiseSkill;
        private float raiseSkillModifier;

        //attack
        private HitData.DamageTypes percentDamageModifier;

        //stamina
        private float staminaOverTime;
        private float staminaOverTimeDuration;
        private float staminaDrainPerSec;
        private float runStaminaDrainModifier;
        private float jumpStaminaUseModifier;
        private float attackStaminaUseModifier;
        private float blockStaminaUseModifier;
        private float dodgeStaminaUseModifier;
        private float swimStaminaUseModifier;
        private float homeItemStaminaUseModifier;
        private float sneakStaminaUseModifier;
        private float runStaminaUseModifier;

        //regen
        private float healthRegenMultiplier = 1f;
        private float staminaRegenMultiplier = 1f;
        private float eitrRegenMultiplier = 1f;

        public StatusEffectsConfig(string _unityEffectsName, string _name, string _tooltip) 
        {
            unityEffectsName = _unityEffectsName;
            name = _name;
            tooltip = _tooltip;
        }

        public SESkillConfig()
        {
            //todo
        }

        public SEAttackConfig()
        {
            //todo
        }

        public SEStaminaConfig()
        {
            //todo
        }

        public SERegenConfig()
        {
            //todo
        }
    }
}
