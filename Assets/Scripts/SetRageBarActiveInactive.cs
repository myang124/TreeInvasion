using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRageBarActiveInactive : MonoBehaviour {

    public GameObject RageOb;


    public void Enable()
    {
        RageOb.SetActive(true);
    }
}
