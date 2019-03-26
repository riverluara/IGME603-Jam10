using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeManager : MonoBehaviour {
    public GameObject[] _nodes;
    public static GameObject[] nodes;
    private static NodeManager nodeManager = null;
    public static NodeManager getInstance() { return nodeManager; }

    private static int NodeCount = 0;

    void Start(){
        if (nodeManager == null) nodeManager = this;
        nodes = _nodes;

        if (NodeCount < nodes.Length) { nodes[NodeCount].GetComponent<Node>().IsLocked = false;}

        if (nodes.Length != 0){
            bool isSaved = PlayerPrefs.HasKey(nodes[0].name);

            if(!isSaved){ loadNodeData();
            Debug.Log("Saved"); }
            else{ foreach(GameObject node in nodes){ saveNodeData(node); }}
        }
        else { Debug.Log("No node");}
    }

    static void saveNodeData(GameObject node){
        Node n = node.GetComponent<Node>();

        if (n != null) {
            PlayerPrefs.SetString(node.name, node.name);
            PlayerPrefs.SetInt(node.name + "isFinished", Convert.ToInt32(n.IsFinished));
            PlayerPrefs.SetInt(node.name + "isLocked", Convert.ToInt32(n.IsLocked));
        }  
    }

    static void loadNodeData(){
        foreach(GameObject node in nodes){
            Node n = node.GetComponent<Node>();

            n.IsFinished = PlayerPrefs.GetInt(node.name + "isFinished") != 0;
            n.IsLocked = PlayerPrefs.GetInt(node.name + "isLocked") != 0;
        }
    }

    public void loadScene(GameObject node){
        Node n = node.GetComponent<Node>();
        n.switchScene();
    }


}
