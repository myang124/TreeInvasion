using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TreeBarFixed))]
public class Map2RageBar : MonoBehaviour {

	public GameObject rageBar;
	public GameObject destroyButton;
    public GameObject scoreAdderTree1;
    public GameObject scoreAdderTree2;
    public GameObject scoreAdderTree3;
    public Text score;
    public int scoreCount;
    private bool tree1Cut = false;
    private bool tree2Cut = false;
    private bool tree3Cut = false;

    private void Start() {
		destroyButton.SetActive(false);
		rageBar.SetActive(false);
	}
    void Update()
    {
        score.text = "SCORE: " + scoreCount;
    }
    public void StartRageBar() {
		rageBar.SetActive(true);
		destroyButton.SetActive(true);
        GetComponent<Map2PlayerMovement>().canMove = false;
	}

	public void DestroyTree() {
		if(GetComponent<TreeBarFixed>()._inZone && GetComponent<TreeTrigger>().Tree11 == true) {
			destroyButton.SetActive(false);
			rageBar.SetActive(false);
			GameObject.Destroy(GetComponent<TreeTrigger>().tree1);
            GetComponent<Map2PlayerMovement>().canMove = true;
            scoreCount += 2;
            GetComponent<Timer>().sec += 2;
            tree1Cut = true;
            tree2Cut = false;
            tree3Cut = false;
            StartCoroutine(showScore());
        }
        if (GetComponent<TreeBarFixed>()._inZone && GetComponent<TreeTrigger>().Tree22 == true)
        {
            destroyButton.SetActive(false);
            rageBar.SetActive(false);
            GameObject.Destroy(GetComponent<TreeTrigger>().tree2);
            GetComponent<Map2PlayerMovement>().canMove = true;
            scoreCount += 4;
            GetComponent<Timer>().sec += 4;
            tree1Cut = false;
            tree2Cut = true;
            tree3Cut = false;
            StartCoroutine(showScore());
        }
       if (GetComponent<TreeBarFixed>()._inZone && GetComponent<TreeTrigger>().Tree33 == true)
        {
            destroyButton.SetActive(false);
            rageBar.SetActive(false);
            GameObject.Destroy(GetComponent<TreeTrigger>().tree3);
            GetComponent<Map2PlayerMovement>().canMove = true;
            scoreCount += 6;
            GetComponent<Timer>().sec += 6;
            tree1Cut = false;
            tree2Cut = false;
            tree3Cut = true;
            StartCoroutine(showScore());
        }
       if(GetComponent<TreeBarFixed>()._inZone == false)
        {
            LoseTimeOnFail();
        }
	}

    public void LoseTimeOnFail()
    {
        GetComponent<Map2PlayerMovement>().restartPlayer();
        destroyButton.SetActive(false);
        rageBar.SetActive(false);

    }
    IEnumerator showScore()
    {
        if (tree1Cut == true)
        {
            scoreAdderTree1.SetActive(true);
            yield return new WaitForSeconds(2);
            scoreAdderTree1.SetActive(false);
        }
        if (tree2Cut == true)
        {
            scoreAdderTree2.SetActive(true);
            yield return new WaitForSeconds(2);
            scoreAdderTree2.SetActive(false);
        }
        if (tree3Cut == true)
        {
            scoreAdderTree3.SetActive(true);
            yield return new WaitForSeconds(2);
            scoreAdderTree3.SetActive(false);
        }
    }
}
