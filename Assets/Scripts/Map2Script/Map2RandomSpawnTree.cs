using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2RandomSpawnTree : MonoBehaviour
{

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
        if (randx <= -5.197f && randx >= -6.799f && randy >= -6.7f && randy <= 3.02f)
        {
            randx = randx + 1.6f;
        }
        if (randx <= 1.353f && randx >= -.046f && randy >= -2.10f && randy <= 6.7f)
        {
            randx = randx + 1.4f;
        }
        if (randx <= 6.68f && randx >= 5.15f && randy >= -6.7f && randy <= 3.03f)
        {
            randx = randx + 1.7f;
        }
    }


}
