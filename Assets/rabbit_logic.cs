using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit_logic : MonoBehaviour
{
    //The player has the variable turn that we need to have rabbit move around. 
    public MyGameStateController playerScript;

    //The path a rabbit will travel.
    public GameObject[] room_route;

    //Is the rabbit free to run around. This should be set to false when picked up by player or placed back in cage.
    public bool freedom = false; 

    //How fast is the rabbit. 
    public float speed = 1.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(freedom ==  true)
            //The rabbit has escaped so it will traverse the room according to its room_route
            transform.position = Vector3.MoveTowards(transform.position, room_route[playerScript.turn%room_route.Length].transform.position, speed);
        else{
            //Captured so do nothing.
        }
    }
}
