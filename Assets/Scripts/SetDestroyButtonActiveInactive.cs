using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestroyButtonActiveInactive : MonoBehaviour {

    public GameObject EnableDestroyButton;
    public GameObject DisbaleRageButton;

    public void Enable()
    {
        EnableDestroyButton.SetActive(false);
        DisbaleRageButton.SetActive(true);
    }
}
