using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroBehaviour : MonoBehaviour
{
    public PlayerBehaviour player;
    public GameObject hero;
//    public SkillSystem.Skill[] skills;
    public GameObject target;


    public GameObject bF;

    public GameObject[] actionUp;
    
    
    
    void CanInterat () {
        actionUp[0].GetComponent<Button>().interactable = (player.actionsLimit <= 1) ? false : true;
        actionUp[1].GetComponent<Button>().interactable = (player.actionsLimit <= 1) ? false : true;
        actionUp[2].GetComponent<Button>().interactable = (player.actionsLimit <= 2) ? false : true;
        actionUp[3].GetComponent<Button>().interactable = (player.actionsLimit <= 3) ? false : true;
        
        actionUp[0].GetComponent<Button>().interactable = (player.actionsLimit >= 1) ? true : false;
        actionUp[1].GetComponent<Button>().interactable = (player.actionsLimit >= 1) ? true : false;
        actionUp[2].GetComponent<Button>().interactable = (player.actionsLimit >= 2) ? true : false; 
        actionUp[3].GetComponent<Button>().interactable = (player.actionsLimit >= 3) ? true : false;  
    }
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        CanInterat();
    }
}
