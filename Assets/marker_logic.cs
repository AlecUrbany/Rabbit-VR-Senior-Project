using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker_logic : MonoBehaviour
{
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.transform.position + Vector3.up * 500;
    }
}
