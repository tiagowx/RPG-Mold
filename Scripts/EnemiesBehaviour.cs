using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemiesBehaviour : MonoBehaviour
{
    public List<EnemyBehaviour> characters;

    public List<EnemyBehaviour> party;

    public List<Button> actionList;
    public GameObject timeline;

    public int actionsLimit;

    public void SummonParty () {
        for( int i = 0; i < 3; i++){
            party.Add(Instantiate(characters[i],transform));
        }
    }

    public void InsertAction(GameObject action) {
        string type = action.name;
        if(action.transform.parent.name != "Timeline"){
            if (actionsLimit>0) {
                action = Instantiate (action, timeline.transform);                
                actionList.Add(action.GetComponent<Button>());
                switch(type){
                    case "ATTK" : {                        
                        actionsLimit --;
                    } break;
                    case "INST" : {                        
                        actionsLimit --;
                    } break;
                    case "SKL" : {                        
                        actionsLimit -= 2;
                            action.transform.GetComponent<RectTransform>().rect.Set(
                            action.transform.GetComponent<RectTransform>().rect.x,
                            action.transform.GetComponent<RectTransform>().rect.y,240,
                            action.transform.GetComponent<RectTransform>().rect.height); 
                    } break;
                    case "ULT" : {
                        actionsLimit -= 3;
                            action.transform.GetComponent<RectTransform>().rect.Set(
                            action.transform.GetComponent<RectTransform>().rect.x,
                            action.transform.GetComponent<RectTransform>().rect.y,
                            action.transform.GetComponent<RectTransform>().rect.width*3,
                            action.transform.GetComponent<RectTransform>().rect.height); 
                    } break;
                }
            }
        }
    }

    public void RemoveAction(GameObject action) {
        
            switch(action.name){
                case "ATTK(Clone)" : {
                    actionsLimit++;
                    actionList.Remove(action.GetComponent<Button>());
                    Destroy(action);
                } break;
                case "INST(Clone)" : {                        
                    actionsLimit++;
                    actionList.Remove(action.GetComponent<Button>());
                    Destroy(action);
                } break;
                case "SKL(Clone)" : {                        
                    actionsLimit += 2;
                    actionList.Remove(action.GetComponent<Button>());
                    Destroy(action);
                } break;
                case "ULT(Clone)" : {                        
                    actionsLimit += 3;
                    actionList.Remove(action.GetComponent<Button>());
                    Destroy(action);
                } break;
            }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SummonParty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}