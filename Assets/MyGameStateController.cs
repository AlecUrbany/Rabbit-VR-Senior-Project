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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
        SpawnRabbits(hip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRabbits(int[] hip)
    {
        Debug.Log("Spawning rabbit");
        rabbit = Instantiate(rabbit, transform.position, transform.rotation);
        
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
        if(turn%2==0){
            rabbit.transform.position = new Vector3(100.0f, 100.0f, 1.0f);
            }else{
                rabbit.transform.position = transform.position;
            }
    }
}
