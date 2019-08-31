using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill : MonoBehaviour
{
    [System.Serializable]
    public enum SkillType
    {
        ATTACK, BUFF, DEBUFF, EMPTY, HEAL, INSTINCT, SKILL, SPELL, SUMMON, ULTIMATE
    }

    //Social Info
    public string skillName;
    public string description;
    public SkillType skillType;
    public Image icon;

    //Custos e disponibilidade
    public bool isAvailable;
    public int timeCost;
    public int mpCost;
    public int hpCost;
    
    //Dano Aplicado
    public int pDamege;
    public int mDamege;
    
    // buff/debuff
    public bool block;
    public int buffTime;
    public int stackLimit;
    public int slowValue;
    public int bleedValue;
    public int poisonValue;
            
}
