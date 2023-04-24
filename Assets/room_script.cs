using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_script : MonoBehaviour
{
    public GameObject[] pathsigns;
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
        playerScript = MyGameStateController.main;
        RenderSigns(false);
        
    }

    void RenderSigns(bool on)
    {
        if(null == pathsigns)
        {
            return;
        }
        for (int i = 0; i < pathsigns.Length; i++)
        {
            pathsigns[i].GetComponentInChildren<Renderer>().enabled = on;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RenderSigns(true);
        if (other.gameObject.CompareTag("Player")){
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
    private void OnTriggerExit(Collider other)
    {
        RenderSigns(false);
    }

}
