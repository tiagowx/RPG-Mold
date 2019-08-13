using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroBehaviour : MonoBehaviour
{
    public GameObject hero;
    public SkillSystem.Skill[] skills;
    public GameObject target;

    public void SellectTarget(GameObject t){
        if (BattleSystem.currentStatus == BattleSystem.BattleStatus.TARGETSELLECT){
            target= t;
        }
    }

    void OnMouseDown(Collision2D coll){
        SellectTarget(coll.gameObject);
    }

    public GameObject[] ActionUp;
    public GameObject[] ActionSelected;

    public void SelectAction (string s) {
        for (int i = 0; i < 10; i++)
        {
            if(ActionSelected[i] == null)
                switch(s){
                    case "ATTACK":{
                            ActionSelected[i] = ActionUp[0];
                            ActionUp[1].SetActive(false);
                    }break;
                    case "INSTINCT":{
                            ActionSelected[i] = ActionUp[1];
                            ActionUp[1].SetActive(false);   
                    }break;
                    case "SKILL":{
                            ActionSelected[i] = ActionUp[2];
                            ActionUp[1].SetActive(false);  
                    }break;
                    case "ULTIMATE":{
                            ActionSelected[i] = ActionUp[3];
                            ActionUp[1].SetActive(false);  
                    }break;
                }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
