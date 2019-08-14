using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Character : MonoBehaviour {

    public enum BaseClass {WARRIOR, PALADIN, HUNTER, MAGE, DRUID, CLARIG }
    [Header("Status")]
    public Status status;

    public static BattleSystem.Action[] actionsOrderList;

    public GameObject CharacterStatus;

    [Header("Ferramentas de Hud")]
    public Button[] attributesButtons;

    public void StatusRefresh() {
        if(status.experience.statusPoints > 0)
        {
            for (int i = 0; i <= attributesButtons.Length - 1; i++)
            {
                attributesButtons[i].interactable = true;
            }
        }
        else
        {
            for (int i = 0; i <= attributesButtons.Length - 1; i++)
            {
                attributesButtons[i].interactable = false;
            }
        }

        status.StatusRefresh();
        
    }

    public void AddPointButton(string statCurrent)
    {
        if (status.experience.statusPoints > 0)
        {
            switch (statCurrent)
            {
                case "STR": status.battle.physical.strength.AddPoint();
                            status.experience.ConsumeStatusPoints(); break;
                case "CON": status.battle.physical.constituition.AddPoint();
                            status.experience.ConsumeStatusPoints(); break;
                case "DEX": status.battle.physical.dexterity.AddPoint();
                            status.experience.ConsumeStatusPoints(); break;
                case "INT": status.battle.magical.intelligence.AddPoint();
                            status.experience.ConsumeStatusPoints(); break;
                case "MEN": status.battle.magical.mentality.AddPoint();
                            status.experience.ConsumeStatusPoints(); break;
                case "WIT": status.battle.magical.wit.AddPoint();
                            status.experience.ConsumeStatusPoints(); break;
            }
        }
        StatusRefresh();
    }

    public void ShowWindow()
    {
        CharacterStatus.SetActive(!CharacterStatus.activeSelf);
    }

    // Use this for initialization
    void Start ()
    {   
        StatusRefresh();
        status.experience.ReceiveExperience(5000);
    }

    // Update is called once per frame
    void Update () {


    }


}
