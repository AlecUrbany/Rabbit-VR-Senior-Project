using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
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
        Debug.Log("TriggerEnter");
        if (other.gameObject.CompareTag("XR Origin"))
        {
            Debug.Log("Is XR Origin");
            var playerScript = GameObject.Find("XR Origin").GetComponent<MyGameStateController>();
            var rmScript = this.gameObject.GetComponent<room_script>();
            if (playerScript == null) { Debug.Log(other.gameObject.gameObject.name); }
            if (rmScript == null) { Debug.Log("rmScript null"); }

            // take the room number from roomScript and update the current room in playerScript
            if (playerScript.current_room != rmScript.room_number)
            {
                Debug.Log("Room Number changed");
                playerScript.current_room = rmScript.room_number;
                playerScript.IncrementTurn();
            }
        }
    }
}
