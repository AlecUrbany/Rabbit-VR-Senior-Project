using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_script : MonoBehaviour
{
    public Vector3 rabbit_spawn_location;
    public int num_of_rabbits_in_room = 0;
    public int room_number =0;
    public MyGameStateController playerScript;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Player Entered Room");


            // take the room number from roomScript and update the current room in playerScript
            if (playerScript.current_room != room_number)
            {
                playerScript.current_room = room_number;
                playerScript.IncrementTurn();
            }else{
                 Debug.Log("Player is in Room"+ playerScript.current_room);
            }
        }
        Debug.Log("Entered Room");
        if(null != playerScript)
            Debug.Log("Player is in Room" + playerScript.current_room);
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("AmONG US");
    }
}
