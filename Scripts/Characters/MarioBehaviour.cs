using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioBehaviour : MonoBehaviour
{
    public Status status;
    //public Skill [] skills;
    public GameObject target;
    //public Skill s;

    [System.Serializable]
    public class WarriorAttack {
        public Skill skill;
        public void Set(Status myStatus){
            skill.isAvailable = true;

            skill.description = "O Guerreiro avança com sua espada causando " 
                                + myStatus.battle.physical.strength.pAttack + " ~ " + myStatus.battle.physical.strength.pCritical +
                                " de dano. Possibilidade de dano crítico.";
        }
        public void Aply (Status me, Status target) {
            if(Random.Range(0,1) < me.battle.physical.dexterity.criticalChance)           
                skill.pDamege = me.battle.physical.strength.pCritical;
            else 
                skill.pDamege = me.battle.physical.strength.pAttack;
            target.battle.health.ReceiveDamage(skill.pDamege,target.battle.physical.constituition.pDefence);
        }
    }

    public WarriorAttack warriorAttack;
/* 
    public void WarriorInstinct() {
        s = null;
        s.skillName = "Instinct of Warrior";
        s.description = "Força adiversário a ataca-lo, cedendo prioridade de ataque no início do turno." + 
                        status.battle.physical.constituition.blockChance*100 + 
                        " de chance de bloquear o dano totalmente.";
        s.skillType = Skill.SkillType.INSTINCT;
        s.isAvailable = true;
        s.timeCost = 1;
        if(Random.Range(0,1) < status.battle.physical.constituition.blockChance)
            s.block = true;
        else 
            s.block = false;
        
    }
    public Skill WarriorSkill(Character c) {
        s = null;
        s.skillType = Skill.SkillType.SKILL;
        s.skillName = "Fraturar";
        s.isAvailable = true;
        s.timeCost = 2;

        if(Random.Range(0,1) < c.status.battle.physical.dexterity.criticalChance)
            s.pDamege = status.battle.physical.strength.pCritical + c.status.battle.physical.strength.pAttack;
        else 
            s.pDamege = status.battle.physical.strength.pCritical;

        s.description = "Força adiversário a ataca-lo, redusindo o dano recebido em " + 
                        c.status.battle.physical.constituition.blockChance*100 + 
                        "% e devolvendo " +
                        c.status.battle.physical.strength.pCritical + 
                        " de dano físico ao adversário.";
        return s;
    }    
    public Skill WarriorUltimate (Character c) {
        s = null;
        s.skillType = Skill.SkillType.ULTIMATE;
        s.skillName = "Twist of Rage";
        s.timeCost = 4;
        
        if(s.timeCost >= BattleSystem.battle.turn)
            s.isAvailable = true;
        else
            s.isAvailable = false;

        if(Random.Range(0,1) < c.status.battle.physical.dexterity.criticalChance)           
            s.pDamege = c.status.battle.physical.strength.pCritical;
        else 
            s.pDamege = c.status.battle.physical.strength.pAttack;

        s.description = "Gira a espada 3 vezes causando " + 
                        s.pDamege +
                        " de dano em cada giro aos adgersários proximos.";
        
        return s;
    }

*/
    // Start is called before the first frame update
    void Start()
    {
        status.battle.SetStartClassStatus(status.social.baseClass);
        status.StatusRefresh();
        warriorAttack.Set(status);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
