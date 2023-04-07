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

    public void SwitchScene(int selectedLevel = 0){
        //SceneManager.LoadScene("Scene" + selectedLevel);
        Debug.Log(numRabbits);
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