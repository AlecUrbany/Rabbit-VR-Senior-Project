using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyGameStateController : MonoBehaviour
{
    public int current_room = 0;
    public int turn = 0;


    public GameObject[] hip_route;
    public GameObject[] hop_route;

    public GameObject rabbit;
    public Animator rabbit_animator;

    public GameObject hop;
    public GameObject hip;

    //consider populating rabbits into this array. Testing will be done on hop/hip
    public GameObject[] rabbits;

    public GameObject[] rooms = new GameObject[9];

    public GameObject rabbit_marker;
    public GameObject hip_marker;
    public GameObject hop_marker;


    public GameObject player_marker;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
        for(var r = 0;r < rooms.Length;r++)
        {
          rooms[r].GetComponent<room_script>().playerScript = this;
          rooms[r].GetComponent<room_script>().room_number = r;
        }

        SpawnRabbits();
        SpawnFSA();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRabbits()
    {
        Debug.Log("Spawning rabbits");

        // Spawn hip
        hip = Instantiate(rabbit, rooms[0].transform.position, transform.rotation);
        hip.GetComponent<CustomGrabInteractable>().playerScript = this;
        hip.GetComponent<rabbit_logic>().playerScript = this;
        hip.GetComponent<rabbit_logic>().room_route = hip_route;
        hip.GetComponent<rabbit_logic>().freedom = true;

        // Spawn hip marker
        hip_marker = Instantiate(rabbit_marker, hip.transform.position, transform.rotation);
        hip_marker.GetComponent<marker_logic>().parent = hip;

        // Spawn hop
        hop = Instantiate(rabbit, rooms[0].transform.position, transform.rotation);
        hip.GetComponent<CustomGrabInteractable>().playerScript = this;
        hop.GetComponent<rabbit_logic>().playerScript = this;
        hop.GetComponent<rabbit_logic>().room_route = hop_route;
        hop.GetComponent<rabbit_logic>().freedom = false;

        // Spawn hip marker
        hop_marker = Instantiate(rabbit_marker, hop.transform.position, transform.rotation);
        hop_marker.GetComponent<marker_logic>().parent = hop;
        
    }
    public void IncrementTurn()
    {

        turn += 1;
        Debug.Log("Turn is now: " + turn.ToString());
        int routeLen = hip.GetComponent<rabbit_logic>().room_route.Length;
        GameObject rm = hip.GetComponent<rabbit_logic>().room_route[turn % routeLen];
        //Debug.Log("Rabbit room: " + ((turn + 1) % hip.GetComponent<rabbit_logic>().room_route.Length).ToString());
        //Debug.Log("Our room: " + current_room.ToString());
        //Debug.Log("Rabbit room name: " + rm.name + "\troom number: " + rm.GetComponent<room_script>().room_number);
        if (current_room != 0 && current_room == rm.GetComponent<room_script>().room_number)//(turn + 1) % hip.GetComponent<rabbit_logic>().room_route.Length)
        {
            hip.GetComponent<rabbit_logic>().GetCaptured();
        }

    }
    public void CaptureRabbit(){
        hip.GetComponent<rabbit_logic>().GetCaptured();
    }
    void SpawnFSA()
    {
        player = Instantiate(player_marker, gameObject.transform.position, transform.rotation);
        player.GetComponent<marker_logic>().parent = gameObject;
    }

}
