using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem {
    [System.Serializable]
    public enum SkillType
    {
        ATTACK, BUFF, DEBUFF, EMPTY, HEAL, INSTINCT, SKILL, SPELL, SUMMON, ULTIMATE
    }

    [System.Serializable]
    public class Skill
    {
        //Social Imfo
        public string name;
        public string description;
        public SkillType skillType;
        //Custos
        public float timeCast;
        public int mpCost;
        public int hpCost;
        //Dano Aplicado
        public int pDamege;
        public int mDamege;
        /*buff/debuff stats
        public int buffTime;
        public int stackLimit;
        public int slowValue;
        public int bleedValue;
        public int poisonValue;*/
    }

}
