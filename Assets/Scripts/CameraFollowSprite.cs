using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSprite : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

     void Start()
    {
        //subtracts the cameras position with the players to get the starting position
        offset = transform.position - player.transform.position;
    }

     void LateUpdate()
    {
        //updates cameras position by adding players pos with offset
        transform.position = player.transform.position + offset;
    }
}
