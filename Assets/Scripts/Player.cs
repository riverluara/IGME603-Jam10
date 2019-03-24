using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int STR;
    private int AGL;
    private int Speed;
    private int Acc;
    private int Health;
    private int Mana;
    private int EXP = 0;
    private int level = 0;
    
    private int job;

    enum Jobs { Gunner, Brawler, Technomancer, Hacker, Medic};
    int[,] starterValues = { {2,3,3,5,2,0},{5,1,1,3,5,0},{1,2,4,4,2,5},{2,4,4,3,2,0},{1,3,2,3,4,5} };

    // Start is called before the first frame update
    void Start()
    {
        job = Random.Range(0, 5);
        STR = starterValues[job,0];
        AGL = starterValues[job,1];
        Speed = starterValues[job,2];
        Acc = starterValues[job,3];
        Health = starterValues[job,4];
        Mana = starterValues[job,5];
    }

    public int GetJob()
    {
        return job;
    }
}
