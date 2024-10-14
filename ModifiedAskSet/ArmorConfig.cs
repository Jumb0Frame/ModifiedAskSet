using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedAskSet
{
    internal class ArmorConfig
    {
        private string name;
        private string description;

        private int maxQuality;

        private float weight;

        private string setName;
        private int setSize;

        private StatusEffect setStatusEffect;

        private float movementModifier;

        private float armor;
        private float armorPerLvl;

        private float maxDurability;
        private float durabilityPerLvl;

        private float equipTime;


        public ArmorConfig(string _name, string _desc, int _maxQual, float _weight, string _setName, int _setSize, StatusEffect _setSE, float _movementMod, float _armor, float _armorPerLvl, float _maxDura, float _duraPerLvl, float _equipTime) 
        { 
            name = _name;
            description = _desc;
            maxQuality = _maxQual;
            weight = _weight;
            setName = _setName;
            setSize = _setSize;
            setStatusEffect = _setSE;
            movementModifier = _movementMod;
            armor = _armor;
            armorPerLvl = _armorPerLvl;
            baseDurability = _baseDura;
            maxDurability = _maxDura;
            durabilityPerLvl = _duraPerLvl;
            equipTime = _equipTime;
        }

        public  void ApplyConfig(ItemDrop item)
        {
            item.m_itemData.m_shared.m_name = name;
            item.m_itemData.m_shared.m_description = description;
            item.m_itemData.m_shared.m_maxQuality = maxQuality;
            item.m_itemData.m_shared.m_weight = weight;
            item.m_itemData.m_shared.m_setName = setName;
            item.m_itemData.m_shared.m_setSize = setSize;
            item.m_itemData.m_shared.m_setStatusEffect  = setStatusEffect;
            item.m_itemData.m_shared.m_movementModifier = movementModifier;
            item.m_itemData.m_shared.m_armor = armor;
            item.m_itemData.m_shared.m_armorPerLevel = armorPerLvl;
            item.m_itemData.m_shared.m_maxDurability = maxDurability;
            item.m_itemData.m_shared.m_durabilityPerLevel = durabilityPerLvl;
            item.m_itemData.m_shared.m_equipDuration = equipTime;
        }

        //todo anything else needed ?
    }
}
