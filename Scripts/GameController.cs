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
            case "adventure":   gameStatus = GameStatus.ADVENTURE;  break;
            case "battle":      gameStatus = GameStatus.BATTLE;     break;
            case "loading":     gameStatus = GameStatus.LOADING;    break;
            case "menu":        gameStatus = GameStatus.MENU;       break;
            case "start":       gameStatus = GameStatus.START;      break;
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

    



    public void FightBattle()
    {
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
