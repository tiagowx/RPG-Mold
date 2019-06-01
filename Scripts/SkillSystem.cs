using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour {
    public enum SkillType
    {
        ATTACK, BUFF, DEBUFF, HEAL, SPELL, SUMMON
    }
        public GameObject enemy;
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
        //buff/debuff stats
        public int buffTime;
        public int stackLimit;
        public int slowValue;
        public int bleedValue;
        public int poisonValue;
        public Status enemy;
        public void Action()
        {
            switch(skillType)
            {
                case SkillType.ATTACK: {
                        
                    }break;
                case SkillType.BUFF: {

                    }
                    break;
                case SkillType.DEBUFF: {

                    }
                    break;
                case SkillType.HEAL: {

                    }
                    break;
                case SkillType.SPELL: {

                    }
                    break;
                case SkillType.SUMMON: {

                    }
                    break;
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
