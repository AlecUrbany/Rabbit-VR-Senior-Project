using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit_logic : MonoBehaviour
{
    public GameObject[] room_route;
    public bool freedom = false; 
    // Start is called before the first frame update
    public void MoveToNextRoom(int turn)
    {
        transform.position = room_route[turn%room_route.Length].transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
