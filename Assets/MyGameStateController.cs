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

    public GameObject hop;
    public GameObject hip;

    //consider populating rabbits into this array. Testing will be done on hop/hip
    public GameObject[] rabbits;

    public GameObject[] rooms = new GameObject[9];

    public GameObject SceneSwitcher;
    
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
       
        SceneSwitcher = GameObject.Find("SceneSwitcher");
        LevelInfo selectedLevel = SceneSwitcher.GetComponent<SceneSwitcher>().selectedLevel;
        // The DFA matrix can be accessed by selectedLevel.getDFA();
        // The number of rabbits can be accessed by selectedLevel.getNumRabbits();

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
        hip.GetComponent<rabbit_logic>().playerScript = this;
        hip.GetComponent<rabbit_logic>().room_route = hip_route;
        hip.GetComponent<rabbit_logic>().freedom = true;

        // Spawn hop
        hop = Instantiate(rabbit, rooms[0].transform.position, transform.rotation);
        hop.GetComponent<rabbit_logic>().playerScript = this;
        hop.GetComponent<rabbit_logic>().room_route = hop_route;
        hop.GetComponent<rabbit_logic>().freedom = false;
        
    }
    public void IncrementTurn()
    {

        turn += 1;
        Debug.Log("Turn is now: " + turn.ToString());
    }
    public void CaptureRabbit(){
        hip.GetComponent<rabbit_logic>().GetCaptured();
    }

}
