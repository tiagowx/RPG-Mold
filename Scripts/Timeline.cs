using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public List <Button> actions;
    public TeamStatus oponnent;
    

    public void GetActions () {

            if(targets.Count < oponnent.partyMenbersLimiter){
                targets.AddRange(oponnent.GetComponentsInChildren<Target>());
            }
            if(actions.Count < GetComponentsInChildren<ActionBerraviour>().Length){
                actions.AddRange(GetComponentsInChildren<Button>());
            }
    }

    public List<Target> targets;
    public int r;
    public Target t;
    public void AplyActions () {
        GetActions ();
        if ((targets.Count>0)&&(actions.Count > 0)){

            for(int i = 0; i < actions.Count; i++) {
                r = Mathf.FloorToInt(Random.Range(0,targets.Count));
                t = targets[r];
                actions[i].transform.Translate(-(transform.position-t.transform.position)*(5.0f*Time.deltaTime),t.transform);

                //actions[i].GetComponent<ActionBerraviour>().target = t;
            }
        }
        
}

    void Start () {

    }

    void Update () {
        if (BattleSystem.currentStatus == BattleSystem.BattleStatus.FIGHT)
            AplyActions();
    }

}
