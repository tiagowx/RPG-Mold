using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroBehaviour : MonoBehaviour
{
    public GameObject hero;
    public SkillSystem.Skill[] skills;
    public GameObject target;

    public GameObject bF;

    public GameObject[] actionUp;
    public GameObject[] actionSelected;
    public GameObject timeline; 
    
    public int times;

    public string parentTest;
    
    public void SelectAction (Button button) {
        if(button.gameObject.transform.parent.name == "Timeline") return;
         
        string s = button.gameObject.name;

        if (times>0){
            for (int i  = 0; i < 10; i++){
                if (actionSelected[i] == null) {
                    switch(s){
                        case "ATTK":{
                            --times;
                            actionSelected[i] = Instantiate(actionUp[0], timeline.transform);
                            return;
                        } 
                        case "INST":{
                            --times;                            
                            actionSelected[i] = Instantiate(actionUp[1], timeline.transform);
                            return;
                        }
                        case "SKL":{
                            times -= 2;                            
                            actionSelected[i] = Instantiate(actionUp[2], timeline.transform);
                            return;
                        }
                        case "ULT":{
                            times -= 3;                            
                            actionSelected[i] = Instantiate(actionUp[3], timeline.transform);
                            return;
                        }
                    }
                }         
            }
            return;
        }
    }
    
    void CanInterat () {
        actionUp[0].GetComponent<Button>().interactable = (times <= 1) ? false : true;
        actionUp[1].GetComponent<Button>().interactable = (times <= 1) ? false : true;
        actionUp[2].GetComponent<Button>().interactable = (times <= 2) ? false : true;
        actionUp[3].GetComponent<Button>().interactable = (times <= 3) ? false : true;
        
        actionUp[0].GetComponent<Button>().interactable = (times >= 1) ? true : false;
        actionUp[1].GetComponent<Button>().interactable = (times >= 1) ? true : false;
        actionUp[2].GetComponent<Button>().interactable = (times >= 2) ? true : false; 
        actionUp[3].GetComponent<Button>().interactable = (times >= 3) ? true : false;  
    }

    public void UnSelectAction (Button button) {
        if(button.gameObject.transform.parent.name == "Timeline"){

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        times = 10;
    }

    // Update is called once per frame
    void Update()
    {
        CanInterat();
        
    }
}
