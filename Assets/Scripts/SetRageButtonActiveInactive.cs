using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRageButtonActiveInactive : MonoBehaviour {

    public GameObject EnableRageButton;
    public GameObject DestroyButton;

    public void Enable()
    {
        EnableRageButton.SetActive(false);
        DestroyButton.SetActive(true);
        
    }

}
