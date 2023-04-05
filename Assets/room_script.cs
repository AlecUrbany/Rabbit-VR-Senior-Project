using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_script : MonoBehaviour
{
    public Vector3[] rabbit_spawn_locations;
    public int num_of_rabbits_in_room = 0;
    public int room_number;
    
    public Vector3 GetRabbitPosition(){
        return transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
