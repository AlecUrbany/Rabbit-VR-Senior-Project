using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyGameStateController : MonoBehaviour
{
    int turn = 0;
    //The values represent the rooms in which the rabbit will be in during that given turn.
    int[] hip = new int[] { 1, 2, 4};
    int[] hop = new int[] { 1, 3, 4};
    int[] hippity = new int[] { 1, 2, 4, 5, 6, 7, 8};
    int[] hoppity = new int[] { 1, 3, 4, 5, 6, 7, 8};
    int[] hippy = new int[] { 1, 2, 4 , 5, 8};
    int[] hoppy = new int[] { 1, 3, 4 , 5, 8};
    public GameObject rabbit;
    public GameObject hop_rabbit;
    public GameObject hippity_rabbit;
    public GameObject hoppity_rabbit;

    public GameObject[] gameObjectsArray = new GameObject[9];
    public GameObject road;
    public GameObject farmers_garden;
    public GameObject courtyard;
    public GameObject rose_garden;
    public GameObject stable;
    public GameObject welcome_room;
    public GameObject kitchen;
    public GameObject library;
    public GameObject dining_hall;
    void PopulateRooms() 
    {
    gameObjectsArray[0] = road;
    gameObjectsArray[1] = courtyard;
    gameObjectsArray[2] = stable;
    gameObjectsArray[3] = rose_garden;
    gameObjectsArray[4] = farmers_garden;
    gameObjectsArray[5] = kitchen;
    gameObjectsArray[6] = dining_hall;
    gameObjectsArray[8] = welcome_room;
    gameObjectsArray[7] = library;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
        SpawnRabbits(hip);
        PopulateRooms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRabbits(int[] hip)
    {
        Debug.Log("Spawning rabbit");
        rabbit = Instantiate(rabbit, transform.position, transform.rotation);
        hop_rabbit = Instantiate(hop_rabbit, transform.position, transform.rotation);
        hippity_rabbit = Instantiate(hippity_rabbit, transform.position, transform.rotation);
        hoppity_rabbit = Instantiate(hoppity_rabbit, transform.position, transform.rotation);
        
    }
    void PrintRabbitLocations()
    {
        Debug.Log("Hip is in room: " + hip[turn % (hip.Length)].ToString());
        Debug.Log("Hopp is in room: " + hop[turn % (hop.Length)].ToString());
        Debug.Log("Hippity is in room: " + hippity[turn % (hippity.Length)].ToString());
        Debug.Log("Hoppity is in room: " + hoppity[turn % (hoppity.Length)].ToString());
        Debug.Log("Hippy is in room: " + hippy[turn % (hippy.Length)].ToString());
        Debug.Log("Hoppy is in room: " + hoppy[turn % (hoppy.Length)].ToString());

    }
    public void IncrementTurn()
    {
        turn += 1;
        Debug.Log("Turn is now: " + turn.ToString());
        PrintRabbitLocations();
        rabbit.transform.position = gameObjectsArray[hip[turn%hip.Length]].transform.position;
        Debug.Log("Hip is at " + rabbit.transform.position.ToString());
        hop_rabbit.transform.position = gameObjectsArray[hop[turn%hop.Length]].transform.position;
        Debug.Log("Hop is at " + hop_rabbit.transform.position.ToString());
                hippity_rabbit.transform.position = gameObjectsArray[hippity[turn%hippity.Length]].transform.position;
        Debug.Log("Hippity is at " + hippity_rabbit.transform.position.ToString());
                hoppity_rabbit.transform.position = gameObjectsArray[hoppity[turn%hoppity.Length]].transform.position;
        Debug.Log("Hoppity is at " + hoppity_rabbit.transform.position.ToString());
    }
}
