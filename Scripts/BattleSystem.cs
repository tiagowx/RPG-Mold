using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [System.Serializable]
    public enum BattleStatus{
        PEACE, ACTIONSELLECT, TARGETSELLECT, FIGHT
    }
    public static BattleStatus currentStatus;

    public class Battle {
        public int id;
        public string fieldBattle;
        public int turn;
        public float timer;
    }
    public static Battle battle;

    [System.Serializable]
    public class Action {
        public GameObject from;
        public GameObject target;
        public Button actionButton;
        public int costTime;
        public string message;
    }
    public static Action [] actions;
    
    //public static GameObject[] fightTimeline;

    public GameObject timeline;

    public int turn = 10;
    public Text consoleMessage;
   


    public int t;

    public List<Button> fightTimeline;
    public GameObject teamA;
    public GameObject teamB;
    
    public void GetActions (List<Button> b1, List<Button> b2) {
        for(int i = 0; i > b1.Count + b2.Count; i++){
            if (Random.Range(0,1)<0.5f){
                fightTimeline.Add(b1[i]);
                b1.Remove(b1[i]);
            }else {
                fightTimeline.Add(b2[i]);
                b2.Remove(b2[i]);
            }
            Instantiate(fightTimeline[i].gameObject,timeline.transform);
        }
    } 
    
    public GameObject team;
    void Start() {
        currentStatus = BattleStatus.ACTIONSELLECT;
//        teamA = Instantiate(team,gameObject.transform.parent.transform);
 //       teamB = Instantiate(team,gameObject.transform.parent.transform);
    }

public void ChangePhase (){
    switch (currentStatus) {
        case BattleStatus.ACTIONSELLECT : currentStatus = BattleStatus.FIGHT; break;
        case BattleStatus.FIGHT : currentStatus = BattleStatus.ACTIONSELLECT; break;
    } 
}

    void Update(){

    }

}
