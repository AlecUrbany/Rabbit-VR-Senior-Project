using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public static LevelInfo[] InitializeLevels(){

        LevelInfo level_1 = new LevelInfo(new string[2]{"HIP", "HOP"}); // Case
        LevelInfo level_2 = new LevelInfo(new string[2]{"HOP", "HIPPITY"}); // Case 01458...
        LevelInfo level_3 = new LevelInfo(new string[2]{"HIPHOP", "HIPPITYHOP"}); // Case 0101018...
        LevelInfo level_4 = new LevelInfo(new string[2]{"HOPHIPPY", "HIPPITYHIP"}); // Case 0101878...
        LevelInfo level_5 = new LevelInfo(new string[3]{"HOP", "HIPPITY", "HIPPY"}); // Case 01810...

        return new LevelInfo[5]{level_1, level_2, level_3, level_4, level_5};
    }

    public void SwitchScene(int selectedLevelIndex = 0){
        LevelInfo[] levels = InitializeLevels();
        LevelInfo selectedLevel = levels[selectedLevelIndex - 1];

        SceneManager.LoadScene("WorkingScene");
    }

}

public class LevelInfo
{

    int numRabbits;
    ArrayList rabbitDFA;

    public LevelInfo(string[] rabbitNames){
        this.numRabbits = rabbitNames.Length;

        this.rabbitDFA = new ArrayList();
        foreach (string rabbitName in rabbitNames){
            this.rabbitDFA.Add(parseDFA(rabbitName));
        }

    }

    public ArrayList getDFA(){
        return this.rabbitDFA;
    }

    static int[] parseDFA(string rabbitName){

        // Hip
        if (rabbitName == "HIP"){
            return new int[3]{1, 2, 4};
        }

        // Hop
        if (rabbitName == "HOP"){
            return new int[3]{1, 3, 4};
        }

        // Hippity
        if (rabbitName == "HIPPITY"){
            return new int[7]{1, 2, 4, 5, 6, 7, 8};
        }

        // Hippy
        if (rabbitName == "HIPPY"){
            return new int[5]{1, 2, 4, 5, 8};
        }

        // HipHop
        if (rabbitName == "HIPHOP"){
            return Union(parseDFA("HIP"), parseDFA("HOP"));
        }

        // HippityHop
        if (rabbitName == "HIPPITYHOP"){
            return Union(parseDFA("HIPPITY"), parseDFA("HOP"));
        }

        // HopHippy
        if (rabbitName == "HOPHIPPY"){
            return Union(parseDFA("HOP"), parseDFA("HIPPY"));
        }

        // HippityHip
        if (rabbitName == "HIPPITYHIP"){
            return Union(parseDFA("HIPPITY"), parseDFA("HIP"));
        }


        return new int[]{};
    }

    static int[] Union(int[] first, int[] second){

        int[] output = new int[first.Length + second.Length];

        for (int i = 0; i < first.Length + second.Length; i++){
            if (i < first.Length){
                output[i] = first[i];
            } else {
                output[i] = second[i - first.Length];
            }
        }

        return output;
    }

}