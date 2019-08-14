using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public void ActionInstantiate(GameObject action){
        Instantiate(action,gameObject.transform);
    }

}
