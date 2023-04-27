using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionalScript : MonoBehaviour
{
    public GameObject escapeMesssage;
    public MyGameStateController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = MyGameStateController.main;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        //escapeMesssage.GetComponentInChildren<Renderer>().enabled = true;
    }
}
