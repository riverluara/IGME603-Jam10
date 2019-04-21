using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleRotation : MonoBehaviour
{
    public Transform templePosition;
    public float force = 5.0f;
    private Vector3 forceDir;
    private Vector3 velocityDir;
    private Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        forceDir = Vector3.Normalize(templePosition.position - this.transform.position);
        velocityDir = Vector3.Cross(forceDir, Vector3.up);
        rg.velocity = force * velocityDir;
        rg.AddForce(forceDir);
        
    }
}
