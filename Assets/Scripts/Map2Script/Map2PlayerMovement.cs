using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Map2PlayerMovement : MonoBehaviour {

    public GameObject txt;
    public Rigidbody2D rb;
    public bool moveLeft;
    public bool moveRight;
    public bool moveUp;
    public bool moveDown;
    public float speed;
    Vector3 pos;
    Transform tr;
    private readonly float MaxX = 11f;
    private readonly float MaxY = 6.7f;
    public bool canMove = true;
    public float moveSpeed;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = rb.transform;
        pos.x = -.58f;
        pos.y = -.04f;
        anim = GetComponent<Animator>();
        anim.SetBool("theParameter", true);
    }

    // Update is called once per frame
    void Update()
    {
        //stops updating once timer hits 0 and shows the end game scene
        if (GetComponent<Timer>().gameIsOver == true)
        {
            SceneManager.LoadScene(9);
            enabled = false;
            if (PlayerPrefs.GetInt("HighScore2") < GetComponent<Map2RageBar>().scoreCount)
            {
                PlayerPrefs.SetInt("HighScore2", GetComponent<Map2RageBar>().scoreCount);
            }
            PlayerPrefs.SetInt("Score2", GetComponent<Map2RageBar>().scoreCount);
        }
        MovePlayer();
        //limits the players movement so it cant leave the scene
        pos.x = Mathf.Clamp(pos.x, -MaxX, MaxX);
        pos.y = Mathf.Clamp(pos.y, -MaxY, MaxY);
        //moves the player when button is pressed
        rb.transform.position = Vector3.MoveTowards(rb.transform.position, pos, speed * Time.deltaTime);
        //blocks player from moving through left root
        PlayerHitsRoots();
    }

    public void CanMoveLeft()
    {
        moveLeft = true;
    }
    public void CantMoveLeft()
    {
        moveLeft = false;
    }
    public void CanMoveRight()
    {
        moveRight = true;
    }
    public void CantMoveRight()
    {
        moveRight = false;
    }
    public void CanMoveUp()
    {
        moveUp = true;
    }
    public void CantMoveUp()
    {
        moveUp = false;
    }
    public void CanMoveDown()
    {
        moveDown = true;
    }
    public void CantMoveDown()
    {
        moveDown = false;
    }
    public void restartPlayer()
    {
        // moves player back to center
        pos.x = -.58f;
        pos.y = -.04f;
        StartCoroutine(Wait());
    }
    // if player his root teleport him back to start
    public void PlayerHitsRoots()
    {
        if (transform.position.x <= -5.197f && transform.position.x >= -6.799f && transform.position.y >= -6.7f && transform.position.y <= 3.02f)
        {
            restartPlayer();
        }
        if(transform.position.x <= 1.353f && transform.position.x >= - .046f && transform.position.y >= -2.10f && transform.position.y <= 6.7f)
        {
            restartPlayer();
        }
        if (transform.position.x <= 6.68f && transform.position.x >= 5.15f && transform.position.y >= -6.7f && transform.position.y <= 3.03f)
        {
            restartPlayer();
        }
    }
    public void MovePlayer()
    {
        //controls for moving UI buttons
        if (moveLeft && !moveRight && !moveUp && !moveDown && tr.position == pos && canMove == true) //Left
        {
            pos += Vector3.left / 14;
            anim.Play("PlayerMoveLeft");
        }
        if (moveRight && !moveLeft && !moveDown && !moveUp && tr.position == pos && canMove == true) //Right
        {
            pos += Vector3.right / 14;
            anim.Play("PlayerMoveRight");
        }
        if (moveUp && !moveLeft && !moveRight && !moveDown && tr.position == pos && canMove == true) //Up
        {
            pos += Vector3.up / 14;
            anim.Play("PlayerMoveUp");
        }
        if (moveDown && !moveLeft && !moveRight && !moveUp && tr.position == pos && canMove == true) //Down
        {
            pos += Vector3.down / 14;
            anim.Play("PlayerMoveDown");
        }
    }

    //method makes player lose two seconds after it hits root
    IEnumerator Wait()
    {
        canMove = false;
        txt.SetActive(true);
        yield return new WaitForSeconds(2);
        canMove = true;
        txt.SetActive(false);
    }
}
