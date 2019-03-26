using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Node : MonoBehaviour {
    public string scenePath;
    private bool isLocked;
    private bool isFinished;

    // Start is called before the first frame update
    void Start() {
        isLocked = false;
        isFinished = false;
    }

    public bool IsLocked{
        get { return this.isLocked; }
        set { this.isLocked = value; }
    }

    public bool IsFinished{
        get { return this.isFinished; }
        set { this.isFinished = value; }
    }

    public void switchScene(){
        Debug.Log("SwitchScene");
        if (!isLocked & !isFinished) SceneManager.LoadScene("test");
        SceneManager.LoadScene("test");
    }

    // public void save(){
    //     saveNodeData();
    // }

    // static void saveNodeData(){
    //         PlayerPrefs.SetString(gameObject.name, gameObject.name);
    //         PlayerPrefs.SetInt(gameObject.name + "isFinished", Convert.ToInt32(isFinished));
    //         PlayerPrefs.SetInt(gameObject.name + "isLocked", Convert.ToInt32(isLocked)); 
    //         PlayerPrefs.Save();
    // }
}
