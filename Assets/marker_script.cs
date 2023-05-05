using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = new Vector3(0,-1,0);
        transform.Rotate(Vector3.forward, 90.0f);
    }
}
