using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10;
	private Rigidbody rigidPlayer;
	// Use this for initialization
	void Start () {
		rigidPlayer = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate()
    {
        float horizontalMove;
        float verticalMove;
        if (Input.GetAxisRaw("Horizontal") != 0 & Input.GetAxisRaw("Vertical") != 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") / 1.414f;
            verticalMove = Input.GetAxisRaw("Vertical") / 1.414f;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");
        }
        rigidPlayer.MovePosition(rigidPlayer.position + new Vector3(speed * Time.deltaTime * horizontalMove, speed * Time.deltaTime * verticalMove, 0.0f));
    }

    void OnTriggerStay(Collider collision) {
        Transform parent = collision.gameObject.transform.parent;
        if (parent != null)
            if(parent.name == "Nodes"){
                //Debug.Log(collision.gameObject.transform.parent.name);
                if(Input.GetKeyDown(KeyCode.J)){
                    NodeManager.getInstance().loadScene(collision.gameObject);
                }
            }
    }
}
