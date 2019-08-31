using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBerraviour : MonoBehaviour
{
    

    public Target target;

    public TeamStatus team;

    public Timeline from;

    void Start () {
        team = transform.parent.transform.parent.GetComponent<TeamStatus>();
        from = transform.parent.GetComponent<Timeline>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
    public Vector3 deltaPosition; 
    void Update () {
        
        if(target != null){
        deltaPosition = transform.position - target.transform.position;
            if ((BattleSystem.currentStatus == BattleSystem.BattleStatus.FIGHT) && 
                (gameObject.transform.parent.name == "Timeline"))
                {
                    transform.Translate(-(transform.position-target.transform.position)*(5.0f*Time.deltaTime),
                    target.transform);
                    if ((deltaPosition.x > -1)&&(deltaPosition.y > -1)){
                        BattleSystem.currentStatus = BattleSystem.BattleStatus.ACTIONSELLECT;
                        team.GetComponent<PlayerBehaviour>().RemoveAction(gameObject);
                        Destroy(gameObject);
                    }
                }

               
        }
    }
    
    
}
