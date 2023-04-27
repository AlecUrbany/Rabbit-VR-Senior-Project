using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class messageScript : MonoBehaviour
{
    string defaultMessage = "Default Message";
    public string winMessage = "Winner!";
    public string loseMessage = "Loser!";

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<Renderer>().enabled = false;
        this.GetComponentInChildren<TextMeshPro>().text = defaultMessage;
    }
    public void WinGame()
    {
        this.GetComponentInChildren<Renderer>().enabled = true;
        this.GetComponentInChildren<TextMeshPro>().text = winMessage;
    }
    public void LoseGame()
    {
        this.GetComponentInChildren<Renderer>().enabled = true;
        this.GetComponentInChildren<TextMeshPro>().text = loseMessage;
    }
    public void SetMessage(string mes)
    {
        this.GetComponentInChildren<Renderer>().enabled = true;
        this.GetComponentInChildren<TextMeshPro>().text = mes;
    }


}
