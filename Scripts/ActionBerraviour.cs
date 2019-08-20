using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBerraviour : MonoBehaviour
{
    public void AutoDestroy(HeroBehaviour hero) {
        if(gameObject.transform.parent.name == "Timeline"){
            
            string s = gameObject.name;
            switch(s){
                case "ATTK(Clone)":{
                    ++hero.times;
                }break;
                case "INST(Clone)":{
                    ++hero.times;
                }break;
                case "SKL(Clone)":{
                    hero.times += 2;
                }break;
                case "ULT(Clone)":{
                    hero.times += 3;
                }break;
            }
            Debug.Log(s + " foi devolvido");
            Destroy(gameObject);
        }
    }
    
}
