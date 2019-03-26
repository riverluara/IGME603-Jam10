using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Node : MonoBehaviour {

    //test part
    public Material material1;
    public Material material2;
    public Material material3;

    //
    public string scenePath;
    private bool isLocked;
    private bool isFinished;

    // Start is called before the first frame update
    void Awake() {
        isLocked = true;
        isFinished = false;
    }

    void Update(){
        if(!isLocked & !isFinished) GetComponent<Renderer>().material = material1;
        if(!isLocked & isFinished) GetComponent<Renderer>().material = material2;
        if(isLocked) GetComponent<Renderer>().material = material3;
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
        if (!isLocked & !isFinished) {
            Debug.Log("Switch to another scene.");
            isFinished = true;
            SceneManager.LoadScene(scenePath);
        }
    }

}
