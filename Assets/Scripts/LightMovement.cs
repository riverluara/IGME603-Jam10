using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    public float minY = -14.81f;
    public float maxY = -9.9f;
    public float minX = -5.74f;
    public float maxX = 13.9f;
    public float speed = 0.3f;
    public float floatingRange = 5.0f;
    private float zPosition = 78.73f;
    private Vector3 originalT;
    // Start is called before the first frame update
    void Start()
    {
        originalT = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, originalT.y+floatingRange * Mathf.Sin(Time.time*speed), this.transform.position.z);
    }
}
