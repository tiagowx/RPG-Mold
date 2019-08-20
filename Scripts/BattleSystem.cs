using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [System.Serializable]
    public enum BattleStatus{
        PEACE, ACTIONSELLECT, TARGETSELLECT, BATTLE
    }
    public BattleStatus currentStatus;

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
    public static Action action;
    
    public static Component[] timeLine;

    public GameObject timeline;

    public int turn = 10;
    public Text consoleMessage;
   
    public void GetAction () {
        for(int i = 0; i > turn; i++){
        }
    } 

    public int t;

    void Start() {
        currentStatus = BattleStatus.ACTIONSELLECT;
    }

    void Update(){
        timeLine = timeline.GetComponentsInChildren<Button>();
        t = timeLine.Length;
    }

}
