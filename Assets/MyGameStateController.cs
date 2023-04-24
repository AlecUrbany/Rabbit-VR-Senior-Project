using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyGameStateController : MonoBehaviour
{
    //public
    [SerializeField]
    [Tooltip("The level determines which mode the game will be played in currently availble: 1 - 5 ")]
    public int level = 1;
    public int current_room = 0;
    [SerializeField]
    [Tooltip("How many rabbits the player can have follow them at a time. ")]
    public int max_followers = 1;
    public static MyGameStateController main;
 
    [SerializeField]
    [Tooltip("The game object that will be spawned and move around the map for the game.")]
    public GameObject rabbit;

    [SerializeField]
    [Tooltip("List of rooms, index matters. 0..8 ")]
    public GameObject[] rooms = new GameObject[9];
    public int turn = 0;
    public int max_turn = 99;
    //private
    private GameObject[] rabbits;
    private int[][] game;
    private string[] gameNames;
    private int number_of_followers = 0;
    private bool game_in_progress = false;

    /*
    Base Rabbit Expressions:
    ----------------------------
    The following arrays represent the states a rabbit can be in.
    More complex rabbits can be concatenated together to produce more complex DFA's
    The levels will do this.
    */
    
     private int[] _HOP = new int[] {1,3,4};
     private int[] _HIP = new int[] {1,2,4};
     private int[] _HOPPITY = new int[] {1,3,4,5,6,7,8};
     private int[] _HIPPITY = new int[] {1,2,4,5,6,7,8};
     private int[] _HOPPY = new int[] {1,3,4,5,8};
     private int[] _HIPPY = new int[] {1,2,4,5,8};

    void Awake()
    {
        main = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");

    }
public void ButtonClicked(int arg)
    {
        
        switch (arg)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                if (!game_in_progress) { KillGame(); CreateGames(arg); }
                game_in_progress = true;
                break;
            case 6:
                KillGame();
                break;
            default:
                break;

        }
    }
public void KillGame()
    {
        if (rabbits == null) { return; }
        for(int i = rabbits.Length - 1; i >= 0; i--)
        {
            Destroy(rabbits[i]);
        }
        rabbits = null;
        turn = 0;
        number_of_followers = 0;
        game_in_progress = false;
    }
public void CreateGames(int level)
{
    switch (level)
    {
        case 1:
            game = new int[2][];
            game[0] = _HOP;
            game[1] = _HIPPITY;
                gameNames = new string[2];
                gameNames[0] = "HOP";
                gameNames[0] = "HIPPITY";
                SpawnRabbits();
                break;

        case 2:
            game = new int[2][];
            game[0] = _HIP.Concat(_HOP).ToArray();
            game[1] = _HIPPITY.Concat(_HOP).ToArray();
                SpawnRabbits();
                break;

        case 3:
            game = new int[2][];
            game[0] = _HOP.Concat(_HIPPY).ToArray();
            game[1] = _HIPPITY.Concat(_HIP).ToArray();
                SpawnRabbits();
                break;

        case 4:
            game = new int[2][];
            game[0] = _HIP;
            game[1] = _HOP;
                SpawnRabbits();
                break;

        case 5:
            game = new int[3][];
            game[0] = _HOP;
            game[1] = _HIPPITY;
            game[2] = _HIPPY;
                SpawnRabbits();
                break;

        default:
            // handle invalid level input
            break;
    }
}
    void checkGameProgress()
    {
        if(turn > max_turn)
        {
            //LOSE GAME!
            Debug.Log("Out of turns!");
        }
        else
        {
            Debug.Log("Remaining turns: " + (max_turn - turn));
        }
        bool haveWinner = true;
        for( int i = 0; i < rabbits.Length; i++) 
        {
            if(rabbits[i].GetComponent<rabbit_logic>().freedom == true || rabbits[i].GetComponent<rabbit_logic>().follow == true)
            {
                haveWinner = false;
                break;
            }
        }
        //WIN GAME!
        if (haveWinner == true)
        {
            game_in_progress = false;
            Debug.Log("Game Won!");
        }
    }
    public void SpawnRabbits()
{
    Debug.Log("Spawning Rabbits:");
    rabbits = new GameObject[game.Length];
    for(int i = 0; i < game.Length; i++)
    {
        rabbits[i] = Instantiate(rabbit, rooms[0].transform.position, transform.rotation);
        //rabbits[i].GetComponent<rabbit_logic>().room_route = hip_route;
        GameObject[] temp_route = new GameObject[game[i].Length];
        for(int j = 0; j < game[i].Length; j++)
        {
            temp_route[j] = rooms[game[i][j]];
        }
        rabbits[i].GetComponent<rabbit_logic>().room_route = temp_route;
        rabbits[i].GetComponent<rabbit_logic>().freedom = true;
        rabbits[i].GetComponent<rabbit_logic>().rabName = gameNames[i];
        }
}


    public void IncrementTurn()
    {

        turn += 1;

        for(int i = 0; i < rabbits.Length; i ++)
        {
            //=turn % rabbits[i].GetComponent<rabbit_logic>().room_route.Length == (rabbits[i].GetComponent<rabbit_logic>().room_route.Length-1)
            int routeLen = rabbits[i].GetComponent<rabbit_logic>().room_route.Length;
            GameObject rm = rabbits[i].GetComponent<rabbit_logic>().room_route[turn % routeLen];
            if(current_room != 0 && current_room == rm.GetComponent<room_script>().room_number && !(turn % rabbits[i].GetComponent<rabbit_logic>().room_route.Length == (rabbits[i].GetComponent<rabbit_logic>().room_route.Length-1)))
            {
                GrabRabbit(rabbits[i]);
            }else if(current_room == 0 && rabbits[i].GetComponent<rabbit_logic>().follow == true)
            {
                CaptureRabbit(rabbits[i]);
            }
        }

        checkGameProgress();
    }
    private void CaptureRabbit(GameObject rabbit)
    {
        
        rabbit.GetComponent<rabbit_logic>().GetCaptured();
        number_of_followers-=1;

    }
    private void GrabRabbit(GameObject rabbit)
    {
        if(max_followers > number_of_followers)
        {
            rabbit.GetComponent<rabbit_logic>().GetGrabbed();
            number_of_followers+=1;
        }
        
    }


}
