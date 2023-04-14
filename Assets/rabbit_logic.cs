using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool moving = false;
  
    //How fast is the rabbit. 
    public float speed = 1.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float threshold = .1f;
       
        Vector3 targetPosition = room_route[playerScript.turn%room_route.Length].transform.position;
        //Debug.Log(Vector3.Distance(transform.position, targetPosition));

        if(freedom ==  true && (Vector3.Distance(transform.position, targetPosition) >= threshold)){
            //The rabbit has escaped so it will traverse the room according to its room_route
            transform.position = Vector3.MoveTowards(transform.position, room_route[playerScript.turn%room_route.Length].transform.position, speed);
            transform.rotation = Quaternion.LookRotation((room_route[playerScript.turn%room_route.Length].transform.position - transform.position).normalized);
            new_rabbit.GetComponent<Animator>().SetBool("IsMoving",true);
            moving = true;
            //animator.SetBool("IsMoving",true);

        }else
        {
            //Debug.Log("HELP");
            new_rabbit.GetComponent<Animator>().SetBool("IsMoving",false);
            moving = false;
            //animator.SetBool("IsMoving",false);
            //Captured so do nothing.
        }
    }
    public void GetCaptured()
    {
        transform.position = playerScript.rooms[0].transform.position;
        freedom = false;

    }
    public void GetGrabbed()
    {
        //transform.position = playerScript.rooms[0].transform.position;
        freedom = false;

    }


    }