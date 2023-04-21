using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit_logic : MonoBehaviour
{
    //The player has the variable turn that we need to have rabbit move around. 
    public MyGameStateController playerScript;
    //The path a rabbit will travel.
    public GameObject[] room_route; 
    public GameObject[] capture_room;//This is the room the rabbit will travel to once its captured.
    public GameObject new_rabbit;
    public Animator animator;
    //Is the rabbit free to run around. This should be set to false when picked up by player or placed back in cage.
    public bool moving = false;
    public bool freedom = false; 
    public bool follow = false;
    //How fast is the rabbit. 
    public float speed = 1.5f;
    public float follow_radius = 10f;
    Vector3 targetPosition;
    void Start()
    {
        playerScript = MyGameStateController.main;
        targetPosition = playerScript.rooms[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float threshold = .1f;//This is going to be the 0 target distance. 
        
        if(freedom == true)//move around the rooms.
        {
            targetPosition = room_route[playerScript.turn%room_route.Length].transform.position;
        }else if(follow == true)//follow the player
        {
            targetPosition = playerScript.transform.position;
        }


        if(follow == true && (Vector3.Distance(transform.position, targetPosition) >= follow_radius))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
            transform.rotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);
        }else if((Vector3.Distance(transform.position, targetPosition) >= threshold)){
            //The rabbit has escaped so it will traverse the room according to its room_route
            //OR rabbit is captured and need to move towards room 0. 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
            transform.rotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);
        }
    }
    public void GetCaptured()//This is called by player when I enter room 0 with a following rabbit.
    {
        freedom = false;
        follow = false;
        targetPosition = playerScript.rooms[0].transform.position;
    }
    public void GetGrabbed()//This is going to be our follow function. 
    {
        freedom = false;
        follow = true;
    }


    }