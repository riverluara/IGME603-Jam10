using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMovement : MonoBehaviour
{
    public float sizeX;


    // Start is called before the first frame update
    void Start()
    {
        sizeX = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLength(float p)
    {
        if(p >=0)
        {
            this.transform.localScale = new Vector3(sizeX * p, this.transform.localScale.y, this.transform.localScale.z);


        }
    }
}
