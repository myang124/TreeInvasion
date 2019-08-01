using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrigger : MonoBehaviour {

	public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject rageButton;
    public bool Tree11;
    public bool Tree22;
    public bool Tree33;

    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Tree1")
        {
			tree1 = other.gameObject;
			rageButton.SetActive(true);
            GetComponent<TreeBarFixed>().dotSpeed = 2;
            Tree11 = true;
            Tree22 = false;
            Tree33 = false;
			//Debug.Log("Player inside tree1 collision!");
		}
        if (other.tag == "Tree2")
        {
            tree2 = other.gameObject;
            rageButton.SetActive(true);
            GetComponent<TreeBarFixed>().dotSpeed = 4;
            Tree11 = false;
            Tree22 = true;
            Tree33 = false;
            //Debug.Log("Player inside tree2 collision!");
        }
        if (other.tag == "Tree3")
        {
            tree3 = other.gameObject;
            rageButton.SetActive(true);
            GetComponent<TreeBarFixed>().dotSpeed = 6;
            Tree11 = false;
            Tree22 = false;
            Tree33 = true;
         //   Debug.Log("Player inside tree3 collision!");
        }
    }

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Tree1") {
			tree1 = null;
			rageButton.SetActive(false);
			//Debug.Log("Player left tree1 collision!");
		}
        if (other.tag == "Tree2")
        {
            tree2 = null;
            rageButton.SetActive(false);
            //Debug.Log("Player left tree2 collision!");
        }
        if (other.tag == "Tree3")
        {
            tree3 = null;
            rageButton.SetActive(false);
            //Debug.Log("Player left tree3 collision!");
        }
    }
	
}
