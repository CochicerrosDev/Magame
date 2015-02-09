using UnityEngine;
using System.Collections;

public class FixedMove : MonoBehaviour {

	public MOVEMENTDIRECTION movementDirection;
	public float speed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		switch(movementDirection) {
			case MOVEMENTDIRECTION.UP: 								
				gameObject.rigidbody2D.AddForce(Vector3.up * speed);				
				break;
			case MOVEMENTDIRECTION.DOWN: 
				gameObject.rigidbody2D.AddForce(Vector3.down * speed);			                             
				break;
			case MOVEMENTDIRECTION.LEFT: 
				gameObject.rigidbody2D.AddForce(Vector3.left * speed);			                             
				break;
			case MOVEMENTDIRECTION.RIGHT: 
				gameObject.rigidbody2D.AddForce(Vector3.right * speed);		
				break;
		}
	}
}
