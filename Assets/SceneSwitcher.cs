using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {




    }

    public void SwitchScene(int selectedLevel = 0)
    {
        //Gets level info
        LevelInfo.get(selectedLevel);
        //debug text
        Debug.Log("Scene Change: " + selectedLevel);
    }

}

public class LevelInfo
{

    int numRabbits;
    int[,] rabbitDFA;

    LevelInfo(){

    }

}