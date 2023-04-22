using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class rabbit_logic : MonoBehaviour
{
    //The player has the variable turn that we need to have rabbit move around. 
    public MyGameStateController playerScript;
    //The path a rabbit will travel.
    public GameObject[] room_route; 
    public GameObject new_rabbit;
    public Animator animator;
    //Is the rabbit free to run around. This should be set to false when picked up by player or placed back in cage.
    public bool freedom = false; 
    public bool follow = false;

    public bool safe = false;
    //How fast is the rabbit. 
    public NavMeshAgent agent;

    void Start()
    {
        playerScript = MyGameStateController.main;
        agent = GetComponent<NavMeshAgent>();

        //This needs to change when we do the start game button. 
        agent.SetDestination(room_route[playerScript.turn%room_route.Length].transform.position);
       
    }

    // Update is called once per frame

    void Update()
    {
        if(playerScript.turn % room_route.Length == (room_route.Length-1))
        {
            safe = true;
        }else
        {
            safe = false;
        }
        
        if(freedom == true)//move to the rooms.
        {
            agent.SetDestination(room_route[playerScript.turn%room_route.Length].transform.position);
        }else if(follow == true)//follow the player
        {
            agent.SetDestination(playerScript.transform.position);
        }else{
            agent.SetDestination(playerScript.rooms[0].transform.position);
        }

    }
    public void GetCaptured()//This is called by player when I enter room 0 with a following rabbit.
    {
        freedom = false;
        follow = false;

        //Change something for the game recognition. 
        //win_game();
    }
    public void GetGrabbed()//This is going to be our follow function. 
    {
        freedom = false;
        follow = true;
    }


    }