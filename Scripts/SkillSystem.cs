using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour{
    [System.Serializable]
    public enum SkillType
    {
        ATTACK, BUFF, DEBUFF, EMPTY, HEAL, INSTINCT, SKILL, SPELL, SUMMON, ULTIMATE
    }

    [System.Serializable]
    public class Skill
    {
        //Social Info
        public string name;
        public string description;
        public SkillType skillType;

        //Custos e disponibilidade
        public bool isAvailable = false;
        public int timeCost;
        public int mpCost;
        public int hpCost;
        
        //Dano Aplicado
        public int pDamege;
        public int mDamege;
        
        // buff/debuff stats
        public bool block;
        public int buffTime;
        public int stackLimit;
        public int slowValue;
        public int bleedValue;
        public int poisonValue;
    }
    public Skill[] skills;
        Skill s;

    public Skill WarriorAttack(Character c) {
        s = null;
        s.name = "Warrior of Attack";
        s.description = "O Guerreiro avança com sua espada causando " + 
                        s.pDamege + 
                        " de dano. Possibilidade de dano crítico";
        s.skillType = SkillType.ATTACK;
        s.isAvailable = true;
        s.timeCost = 1;
        if(Random.Range(0,1) < c.status.battle.physical.dexterity.criticalChance)           
            s.pDamege = c.status.battle.physical.strength.pCritical;
        else 
            s.pDamege = c.status.battle.physical.strength.pAttack;

        return s;
    }
    public Skill WarriorInstinct(Character c) {
        s = null;
        s.name = "Instinct of Warrior";
        s.description = "Força adiversário a ataca-lo, cedendo prioridade de ataque no início do turno." + 
                        c.status.battle.physical.constituition.blockChance*100 + 
                        " de chance de bloquear o dano totalmente.";
        s.skillType = SkillType.INSTINCT;
        s.isAvailable = true;
        s.timeCost = 1;
        if(Random.Range(0,1) < c.status.battle.physical.constituition.blockChance)
            s.block = true;
        else 
            s.block = false;

        return s;
    }

    public Skill WarriorSkill(Character c) {
        s = null;
        s.name = "Counterattack";
        s.description = "Força adiversário a ataca-lo, redusindo o dano recebido em " + 
                        c.status.battle.physical.constituition.blockChance*100 + 
                        "% e devolvendo " +
                        c.status.battle.physical.strength.pCritical + 
                        " de dano físico ao adversário.";
        s.skillType = SkillType.SKILL;
        s.isAvailable = true;
        s.timeCost = 2;
        if(Random.Range(0,1) < c.status.battle.physical.constituition.blockChance)
            s.pDamege = c.status.battle.physical.strength.pCritical + c.status.battle.physical.strength.pAttack;
        else 
            s.pDamege = c.status.battle.physical.strength.pCritical;

        return s;
    }
    

}
