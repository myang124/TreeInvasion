using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Map3PlayerMovement : MonoBehaviour {

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
            SceneManager.LoadScene(8);
            enabled = false;
            if (PlayerPrefs.GetInt("HighScore3") < GetComponent<Map3RageBar>().scoreCount)
            {
                PlayerPrefs.SetInt("HighScore3", GetComponent<Map3RageBar>().scoreCount);
            }
            PlayerPrefs.SetInt("Score3", GetComponent<Map3RageBar>().scoreCount);
        }
        //method allows player to move
        MovePlayer();
        //limits the players movement so it cant leave the scene
        pos.x = Mathf.Clamp(pos.x, -MaxX, MaxX);
        pos.y = Mathf.Clamp(pos.y, -MaxY, MaxY);
        //moves the player when button is pressed
        rb.transform.position = Vector3.MoveTowards(rb.transform.position, pos, speed * Time.deltaTime);
        //blocks player from moving through root
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
        // teleports player back to center
        pos.x = -.58f;
        pos.y = -.04f;
        StartCoroutine(Wait());
    }

    public void PlayerHitsRoots()
    {
        if (transform.position.x >= -2.98f && transform.position.x <= -1.58f && transform.position.y >= 5.3f && transform.position.y <= 6.7f)
        {
            restartPlayer();
        }
        if (transform.position.x >= 1.6f && transform.position.x <= 2.82f && transform.position.y >= 4.3f && transform.position.y <= 6.7f)
        {
            restartPlayer();
        }
        if (transform.position.x >= -10.2f && transform.position.x <= -1.4f && transform.position.y >= 1.76f && transform.position.y <= 2.96f)
        {
            restartPlayer();
        }
        if (transform.position.x >= 1.42f && transform.position.x <= 4.82f && transform.position.y >= 2.16f && transform.position.y <= 2.96f)
        {
            restartPlayer();
        }
        if (transform.position.x >= 6.02f && transform.position.x <= 11f && transform.position.y >= 1.76f && transform.position.y <= 2.76f)
        {
            restartPlayer();
        }
        if (transform.position.x >= -11f && transform.position.x <= -8.4f && transform.position.y >= -2.04f && transform.position.y <= -1.24f)
        {
            restartPlayer();
        }
        if (transform.position.x >= -7.37f && transform.position.x <= -1.58f && transform.position.y >= -2.24f && transform.position.y <= -1.04f)
        {
            restartPlayer();
        }
        if (transform.position.x >= -2.78f && transform.position.x <= -1.38f && transform.position.y >= -4.84f && transform.position.y <= -1.04f)
        {
            restartPlayer();
        }
        if (transform.position.x >= 4.22f && transform.position.x <= 11f && transform.position.y >= -2.24f && transform.position.y <= -1.04f)
        {
            restartPlayer();
        }
        if (transform.position.x >= 1.62f && transform.position.x <= 3.02f && transform.position.y >= -3.64f && transform.position.y <= -1.24f)
        {
            restartPlayer();
        }
        if (transform.position.x >= 1.62f && transform.position.x <= 2.82f && transform.position.y >= -6.7f && transform.position.y <= -4.64f)
        {
            restartPlayer();
        }

    }
    public void MovePlayer()
    {
        //controls for moving UI buttons
        if (moveLeft && !moveRight && !moveUp && !moveDown && tr.position == pos && canMove == true)
        {
            pos += Vector3.left / 14;
            anim.Play("PlayerMoveLeft");
        }
        if (moveRight && !moveLeft && !moveDown && !moveUp && tr.position == pos && canMove == true)
        {
            pos += Vector3.right / 14;
            anim.Play("PlayerMoveRight");
        }
        if (moveUp && !moveLeft && !moveRight && !moveDown && tr.position == pos && canMove == true)
        {
            pos += Vector3.up / 14;
            anim.Play("PlayerMoveUp");
        }
        if (moveDown && !moveLeft && !moveRight && !moveUp && tr.position == pos && canMove == true)
        {
            pos += Vector3.down / 14;
            anim.Play("PlayerMoveDown");
        }
    }
    // method makes player lose seconds from running into a root
    IEnumerator Wait()
    {
        txt.SetActive(true);
        canMove = false;
        yield return new WaitForSeconds(2);
        canMove = true;
        txt.SetActive(false);
    }
}
