using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabInteractable : XRGrabInteractable
{
    public MyGameStateController playerScript;

    [SerializeField]
    private bool _shouldReleaseOnBoolChange = true;

    protected override void Grab()
    {
        Debug.Log("HELP");
        if (playerScript.current_room == 0)
        {
            base.Grab();
        }
    }
    
    protected override void Detach()
    {
        Debug.Log("HELP");
        if (playerScript.current_room == 0)
        {
            base.Detach();
        }
    }

    protected override void Drop()
    {
        Debug.Log("HELP");
        if (playerScript.current_room == 0)
        {
            base.Drop();
        }
    }
   
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("HELP");
        if (playerScript.current_room == 0)
        {
            base.OnSelectEntered(args);
        }
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        Debug.Log("HELP");
        if (playerScript.current_room == 0)
        {
            base.OnSelectEntering(args);
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("HELP");
        if (playerScript.current_room == 0)
        {
            base.OnSelectExited(args);
        }
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        Debug.Log("HELP");
        if (playerScript.current_room == 0)
        {
            base.OnSelectExiting(args);
        }
    }
}
