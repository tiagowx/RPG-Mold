using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamStatus : MonoBehaviour
{

    public int partyMenbersLimiter;

    void Start () {
        partyMenbersLimiter = GetComponentsInChildren<Target>().Length;
    }
}
