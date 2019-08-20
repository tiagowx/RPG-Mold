using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private enum GameStatus
    {
        ADVENTURE, BATTLE, LOADING, MENU, START
    }
    private static GameStatus gameStatus;

    public static void ChangeGameStatus(string toState)
    {
        switch (toState)
        {
            case "adventure":   GameStatus1 = GameStatus.ADVENTURE;  break;
            case "battle":      GameStatus1 = GameStatus.BATTLE;     break;
            case "loading":     GameStatus1 = GameStatus.LOADING;    break;
            case "menu":        GameStatus1 = GameStatus.MENU;       break;
            case "start":       GameStatus1 = GameStatus.START;      break;
        }
    }

    //BATTLE SYSTEM

    [System.Serializable]
    enum BattleTurn
    {
        BEGIN, SELECTION, FIGHT, END
    }
    [Header("Battle System")]
    private BattleTurn turnStats;

    [Header("Time Limit")]
    public float beginTime;
    public float selectionTime;
    public float fightTime;
    public float endTime;

    public GameObject HUDStatus;
    public GameObject StatusTitle;
    public Vector3 vt1;
    public Vector3 vt2;

    private static GameStatus GameStatus1 { get => gameStatus; set => gameStatus = value; }

    public void HUDTransform () {
        vt1 = HUDStatus.transform.position;
        vt2 = Input.mousePosition;
        Vector3 v = new Vector3(0,0,0);
        v = Input.mousePosition - StatusTitle.transform.position;
        HUDStatus.transform.position += v;
    }


	// Use this for initialization
	void Start () {
		ChangeGameStatus("battle");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
