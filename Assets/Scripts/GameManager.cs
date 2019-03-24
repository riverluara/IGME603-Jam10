using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    private Player player;
    private int job;
    public string[] lines;
    public List<string> commands;


    void Start()
    {
        player = Player.GetComponent<Player>();
        job = player.GetJob();
        ReadFromFile();
        MakeValid();
    }

    void ReadFromFile()
    {
        StreamReader inStream = new StreamReader("Assets/Files/Commands.txt");
        string file = inStream.ReadToEnd();
        inStream.Close();
        lines = file.Split("\n"[0]);
    }

    void MakeValid()
    {
        string inputs = lines[job];
        string[] temp = inputs.Split(" "[0]);
        commands = new List<string>(temp);
        commands.RemoveAt(0);
    }
}
