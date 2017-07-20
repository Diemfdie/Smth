using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public bool canMove = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canMove)
            transform.position += new Vector3(Input.GetAxis("Horizontal") / speed, 0.0f, Input.GetAxis("Vertical") / speed);
    }

    public void DisableMoving()
    {
        canMove = false;
    }

    public void EnableMoving()
    {
        canMove = true;
    }
}
