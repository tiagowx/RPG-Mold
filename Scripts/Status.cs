using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public enum BaseClass { WARRIOR, PALADIN, HUNTER, MAGE, DRUID, CLARIG }

[System.Serializable]
public class Status
{
    [System.Serializable]
    public class Social
    {
        private string charName;
        public Text txtCharName;
        public BaseClass baseClass;
        public Text txtBaseClass;
        public void SetCharName (string newCharName) { charName = newCharName; }
        public void Refresh ()
        {
            txtCharName.text = "Nome: " + charName;
            txtBaseClass.text = "Class: " + baseClass.ToString();
        }
    }
    public Social social;

    [System.Serializable]
    public class Experience
    {
        private int maxLevel=30;
        public int level { get; private set; }
        public int[] levelList;
        public Text txtLevel;
        public HorizontalLayoutGroup barExp;
        private int exp;
        private int toNextLevel;
        public Text txtExp;
        public int statusPoints { get;  private set;}
        public Text txtStatusPoints;
        public void NextLevel() {
            SetLevelList();
            if (exp > toNextLevel) {
                if (level < 1)
                {
                    level = 1;
                    toNextLevel = levelList[level-1];
                }
                Debug.Log("EXP: " + exp + " Level: " + level + "Subtração: ");
                if (exp >= toNextLevel)
                {
                    exp -= levelList[level-1];
                    statusPoints += 3;
                    level++;
                    toNextLevel = levelList[level-1];
                }
            }
            Debug.Log("EXP: " + exp + " Level: " + level + "Subtração: ");
        }
        public void ReceiveExperience(int xp)
        {
            exp += xp;
            while (exp > toNextLevel) { NextLevel(); }
            Refresh();
        }
        public void ConsumeStatusPoints() { statusPoints--; }
        public void SetLevelList ()
        {
            for(int i = 0; i < maxLevel; i++)
            {
                if (i == 0)
                {
                    levelList[i] = 100;
                }else
                {
                    levelList[i] = levelList[i-1] + (50 * i);
                }
            }
        }
        public void SetLevel(int n) { level = n; }
        public void Refresh()
        {
            if (level < 1)
            {
                level = 1;
                toNextLevel = levelList[level - 1];
            }
            txtLevel.text = "Level: " + level;
            txtExp.text = "Exp: " + exp + " / " + toNextLevel;
            txtStatusPoints.text = "Status Points: " + statusPoints;
            BarSizeChange(exp,toNextLevel-1,barExp);
        }
    }
    public Experience experience;

    [System.Serializable]
    public class Battle
    {
        //Health System
        [System.Serializable]
        public class Health
        {
            public int hp { get;  private set; }
            public Text txtHp;
            // public float hpPercent;
            public HorizontalLayoutGroup barHp;
            public void HealDamage(int heal) { hp += heal; }
            public void SetHealth(int newHP) { hp = newHP; }
            public void ReceiveDamage(int grossDamage, int reductions)
            {
                hp -= grossDamage - reductions;
                Debug.Log("recebeu " + (grossDamage - reductions));
                //return grossDamage - reductions;
            }
            public void StartHealth(int maxHp)
            {
                SetHealth(maxHp);         
            }
        }
        [Header("Battle Situation")]
        public Health health;
        public void RestoreFullHP() {
            health.SetHealth(physical.constituition.maxHP);
        }
        public void HealthRefresh() {
            health.txtHp.text = "HP: " + health.hp + " / " + physical.constituition.maxHP;
            BarSizeChange(health.hp,physical.constituition.maxHP,health.barHp);
        }
        //Mana System
        [System.Serializable]
        public class Mana
        {
            public int mp { get; private set; }
            public Text txtMp;
            public HorizontalLayoutGroup barMp;
            public void ManaConsumption(int coast) {
                mp = mp - coast;
                Debug.Log("consumiu " + (coast));
            }
            public void SetMana(int newMP) { mp = newMP; }
            public void ReceiveDamage(int grossDamage, int reductions)
            { mp -= grossDamage - reductions; }
        }
        public Mana mana;
        public void RestoreFullMP() { mana.SetMana(magical.mentality.maxMP); }
        public void ManaRefresh() {
            mana.txtMp.text = "MP: " + mana.mp + " / " + magical.mentality.maxMP;
            BarSizeChange(mana.mp, magical.mentality.maxMP, mana.barMp);
        }

        //physic
        [System.Serializable]
        public class Physical
        {
            //fisico
            [System.Serializable]
            public class Strength
            {
                private int STR;
                public Text txtSTR;
                public int pAttack { get; private set; }
                public Text txtPAttack;
                private int pCritical;
                public Text txtPCritical;
                public void AddPoint() { STR++; }
                public void SetStartPoints(int n) { STR = n; }
                public Button addSTR;
                public void Refresh()
                {
                    txtSTR.text = STR.ToString();

                    pAttack = STR * 6;
                    txtPAttack.text = pAttack.ToString();

                    pCritical = Mathf.FloorToInt(0.5f * pAttack) + pAttack;
                    txtPCritical.text = pCritical.ToString();
                }
            }
            public Strength strength;

            [System.Serializable]
            public class Constituition
            {
                public int CON { get;  private set; }
                public Text txtCON;
                public int maxHP { get; private set; }
                public Text txtMaxHP;
                public int pDefence { get; private set; }
                public Text txtPDefence;
                private float blockChance;
                public Text txtBlockChance;
                private float determination;
                public Text txtDetermination;
                public void AddPoint() { CON++; }
                public void SetStartPoints(int n) { CON = n; }
                public Button addCON;
                public void Refresh()
                {
                    txtCON.text = CON.ToString();

                    maxHP = CON * 6;
                    txtMaxHP.text = maxHP.ToString();

                    pDefence = Mathf.FloorToInt(CON  * 3f);
                    txtPDefence.text = pDefence.ToString();

                    blockChance = 0.02f * CON;
                    txtBlockChance.text = Mathf.FloorToInt(blockChance * 100) + "%";

                    determination = 0.03f * CON;
                    txtDetermination.text = Mathf.FloorToInt(determination * 100) + "%";
                }
            }
            public Constituition constituition;

            [System.Serializable]
            public class Dexterity
            {
                private int DEX;
                public Text txtDEX;
                private int atkSpeed;
                public Text txtAtkSpeed;
                private int speed;
                public Text txtSpeed;
                private float criticalChance;
                public Text txtCriticalChance;
                private float malice;
                public Text txtMalice;
                public void AddPoint() { DEX++; }
                public void SetStartPoints(int n) { DEX = n; }
                public Button addDEX;
                public void Refresh()
                {
                    txtDEX.text = DEX.ToString();

                    atkSpeed = DEX * 3;
                    txtAtkSpeed.text = atkSpeed.ToString();

                    speed = Mathf.FloorToInt(DEX  * 3f);
                    txtSpeed.text = speed.ToString();

                    criticalChance = 0.025f * DEX;
                    txtCriticalChance.text = Mathf.FloorToInt(criticalChance * 100) + "%";

                    malice = 0.03f * DEX;
                    txtMalice.text = Mathf.FloorToInt(malice * 100) + "%";
                }
            }
            public Dexterity dexterity;
        }
        [Header("Atributos")]
        public Physical physical;

        //magic
        [System.Serializable]
        public class Magical
        {
            [System.Serializable]
            public class Intelligence
            {
                private int INT;
                public Text txtINT;
                private int mPower;
                public Text txtMPower;
                private int overHit;
                public Text txtOverHitPower;
                public void AddPoint() { INT++; }
                public void SetStartPoints(int n) { INT = n; }
                public Button addINT;
                public void Refresh()
                {
                    txtINT.text = INT.ToString();

                    mPower = INT * 6;
                    txtMPower.text = mPower.ToString();

                    overHit = Mathf.FloorToInt(0.5f * mPower) + mPower;
                    txtOverHitPower.text = overHit.ToString();
                }
            }
            public Intelligence intelligence;

            [System.Serializable]
            public class Mentality
            {
                private int MEN;
                public Text txtMEN;
                public int maxMP { get; private set; }
                public Text txtMaxMP;
                private int mProtection;
                public Text txtMProtection;
                private float manaShield;
                public Text txtManaSheild;
                private float resilience;
                public Text txtResilience;
                public void AddPoint() { MEN++; }
                public void SetStartPoints(int n) { MEN = n; }
                public Button addMEN;
                public void Refresh()
                {
                    txtMEN.text = MEN.ToString();

                    maxMP = MEN * 6;
                    txtMaxMP.text = maxMP.ToString();

                    mProtection = Mathf.FloorToInt(MEN  * 3f);
                    txtMProtection.text = mProtection.ToString();

                    manaShield = 0.02f * MEN;
                    txtManaSheild.text = Mathf.FloorToInt(manaShield * 100) + "%";

                    resilience = 0.03f * MEN;
                    txtResilience.text = Mathf.FloorToInt(resilience * 100) + "%";
                }
            }
            public Mentality mentality;

            [System.Serializable]
            public class Wit
            {
                private int WIT;
                public Text txtWIT;
                private int castingSpeed;
                public Text txtCastSpeed;
                private int consentration;
                public Text txtConsentration;
                private float overHitChance;
                public Text txtOverHitChance;
                private float intuition;
                public Text txtIntuition;
                public void AddPoint() { WIT++; }
                public void SetStartPoints(int n) { WIT = n; }
                public Button addWIT;
                public void Refresh()
                {
                    txtWIT.text = WIT.ToString();

                    castingSpeed = WIT * 6;
                    txtCastSpeed.text = castingSpeed.ToString();

                    consentration = Mathf.FloorToInt(WIT * 1.5f);
                    txtConsentration.text = consentration.ToString();

                    overHitChance = 0.025f * WIT;
                    txtOverHitChance.text = Mathf.FloorToInt(overHitChance * 100) + "%";

                    intuition = 0.03f * WIT;
                    txtIntuition.text = Mathf.FloorToInt(intuition * 100) + "%";
                }
            }
            public Wit wit;
        }
        public Magical magical;

        public void SetStartClassStatus(BaseClass b)
        {
            switch (b)
            {
                case BaseClass.WARRIOR:
                    {
                        physical.strength.SetStartPoints(8);
                        physical.constituition.SetStartPoints(8);
                        physical.dexterity.SetStartPoints(3);
                        magical.intelligence.SetStartPoints(3);
                        magical.mentality.SetStartPoints(5);
                        magical.wit.SetStartPoints(3);
                    }
                    break;
                case BaseClass.PALADIN:
                    {
                        physical.strength.SetStartPoints(5);
                        physical.constituition.SetStartPoints(9);
                        physical.dexterity.SetStartPoints(3);
                        magical.intelligence.SetStartPoints(3);
                        magical.mentality.SetStartPoints(7);
                        magical.wit.SetStartPoints(3);
                    }
                    break;
                case BaseClass.HUNTER:
                    {
                        physical.strength.SetStartPoints(6);
                        physical.constituition.SetStartPoints(5);
                        physical.dexterity.SetStartPoints(9);
                        magical.intelligence.SetStartPoints(3);
                        magical.mentality.SetStartPoints(4);
                        magical.wit.SetStartPoints(3);
                    }
                    break;
                case BaseClass.MAGE:
                    {
                        physical.strength.SetStartPoints(3);
                        physical.constituition.SetStartPoints(5);
                        physical.dexterity.SetStartPoints(3);
                        magical.intelligence.SetStartPoints(9);
                        magical.mentality.SetStartPoints(6);
                        magical.wit.SetStartPoints(5);
                    }
                    break;
                case BaseClass.DRUID:
                    {
                        physical.strength.SetStartPoints(5);
                        physical.constituition.SetStartPoints(7);
                        physical.dexterity.SetStartPoints(3);
                        magical.intelligence.SetStartPoints(5);
                        magical.mentality.SetStartPoints(7);
                        magical.wit.SetStartPoints(3);
                    }
                    break;
                case BaseClass.CLARIG:
                    {
                        physical.strength.SetStartPoints(3);
                        physical.constituition.SetStartPoints(6);
                        physical.dexterity.SetStartPoints(3);
                        magical.intelligence.SetStartPoints(5);
                        magical.mentality.SetStartPoints(8);
                        magical.wit.SetStartPoints(5);
                    }
                    break;
            }
        }
    }
    public Battle battle;

    public void StatusRefresh()
    {
        //Conditions
        if (experience.level <= 1) {
            experience.SetLevelList();
            battle.SetStartClassStatus(social.baseClass);
        }

        //Battle Stats
        battle.physical.strength.Refresh();
        battle.physical.constituition.Refresh();
        battle.physical.dexterity.Refresh();
        battle.magical.intelligence.Refresh();
        battle.magical.mentality.Refresh();
        battle.magical.wit.Refresh();



        //Social Stats
        social.Refresh();

        //Experience Stats
        experience.Refresh();

        //extra
        battle.HealthRefresh();
        battle.ManaRefresh();

    }

    //Tools
    public static void BarSizeChange(int maxValue, int currentValue, HorizontalLayoutGroup bar)
    {
        float percent;
        if ((maxValue == 0) || (currentValue == 0))
        {
            bar.padding.right = 5;
        }
        else
        {
            percent = (currentValue * maxValue) / 100;
            Debug.Log(percent + "%");
            bar.padding.right = 5 + Mathf.FloorToInt(295 * (percent / 100));
        }
    }
}


