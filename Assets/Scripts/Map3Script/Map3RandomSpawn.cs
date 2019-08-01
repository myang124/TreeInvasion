using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3RandomSpawn : MonoBehaviour {

    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    float randx;
    float randy;
    Vector2 position;
    public float spawnTimerTree1;
    public float spawnTimerTree2;
    public float spawnTimerTree3;
    float nextSpawn1 = 0.0f;
    float nextSpawn2 = 0.0f;
    float nextSpawn3 = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn1)
        {
            nextSpawn1 = Time.time + spawnTimerTree1;
            randx = Random.Range(-10.5f, 10.5f);
            randy = Random.Range(-6.3f, 6.3f);
            CheckIfInRoot();
            position = new Vector2(randx, randy);
            Instantiate(tree1, position, Quaternion.identity);
        }
        if (Time.time > nextSpawn2)
        {
            nextSpawn2 = Time.time + spawnTimerTree2;
            randx = Random.Range(-10.5f, 10.5f);
            randy = Random.Range(-6.3f, 6.3f);
            CheckIfInRoot();
            position = new Vector2(randx, randy);
            Instantiate(tree2, position, Quaternion.identity);
        }
        if (Time.time > nextSpawn3)
        {
            nextSpawn3 = Time.time + spawnTimerTree3;
            randx = Random.Range(-10.5f, 10.5f);
            randy = Random.Range(-6.3f, 6.3f);
            CheckIfInRoot();
            position = new Vector2(randx, randy);
            Instantiate(tree3, position, Quaternion.identity);
        }
    }

     void CheckIfInRoot()
    {
        if (randx >= -2.98f && randx <= -1.58f && randy >= 5f && randy <=6.7f)
        {
            randx = randx - 2;
        }
        if (randx >= 1.6f && randx <= 2.82f && randy >= 4.3f && randy <= 6.7f)
        {
            randx = randx + 2;
        }
        if (randx >= -10.2f && randx <= 1.4f && randy >= 1.76f && randy <= 2.96f)
        {
            randy++;
        }
        if (randx >= 1.42f && randx <= 4.82f && randy >= 2.16f && randy <= 2.96f)
        {
            randy--;
        }
        if (randx >= 6.02f && randx <= 11f && randy >= 1.76f && randy <= 2.76f)
        {
            randy = randy + 2; ;
        }
        if (randx >= -11f && randx <= -8.4f && randy >= -2.04f && randy <= -1.24f)
        {
            randy = randy - 2; 
        }
        if (randx >= -7.37f && randx <= -1.58f && randy >= 2.24f && randy <= -1.04f)
        {
            randy = randy++;
        }
        if (randx >= -2.78f && randx <= -1.38f && randy >= -4.84f && randy <= -1.04f)
        {
            randx = randx + 2;
        }
        if (randx >= 4.22f && randx <= 11f && randy >= -2.24f && randy <= -1.04f)
        {
            randy = randy - 2; ;
        }
        if (randx >= 1.62f && randx <= 3.02f && randy >= -3.64f && randy <= -1.24f)
        {
            randx = randx - 1.5f;
        }
        if (randx >= 1.62f && randx <= 2.82f && randy >= -6.7f && randy <= -4.64f)
        {
            randx = randx + 2;
        }
    }
}
