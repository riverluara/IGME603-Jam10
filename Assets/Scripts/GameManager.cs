using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using RawInput_dll;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    private Player player;
    private Player player2;
    private int job;
    public string[] lines;
    public KeyCode[] playerOneKeys = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B };
    public KeyCode[] playerTwoKeys = { KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.N, KeyCode.M };
    public List<string> commands;
    public string P1String;
    public string P2String;
    //public RawInput rawInput;
    

    void Start()
    {
        //rawInput = new RawInput(GetWindowHandle(), true);

        player = PlayerOne.GetComponent<Player>();
        player2 = PlayerTwo.GetComponent<Player>();
        //job = player.GetJob();
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

     void Update()
    {
       foreach(KeyCode key in playerOneKeys)
        {
            if (Input.GetKeyDown(key) && Input.GetKey(KeyCode.Alpha1)) { P1String += key.ToString(); }
        }

       foreach(KeyCode key in playerTwoKeys)
        {
            if (Input.GetKeyDown(key) && Input.GetKey(KeyCode.Return)) { P2String += key.ToString(); }
        }

    }

    void CallCommand(string command, int player)
    {
        if (player == 0) { P1String = ""; }
        else P2String = "";


    }

    //[System.Runtime.InteropServices.DllImport("user32.dll")]
    //private static extern System.IntPtr GetActiveWindow();

    //public static System.IntPtr GetWindowHandle()
    //{
    //    return GetActiveWindow();
    //}
}
