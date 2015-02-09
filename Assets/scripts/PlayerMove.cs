using UnityEngine;
using System.Collections;

// Possible movement directions
public enum MOVEMENTDIRECTION
{
	UP,
	DOWN,
	LEFT,
	RIGHT,
	NONE}
;
// Weapons
public enum MAGIC
{
	FIRE,
	ICE
}
;

public class PlayerMove : MonoBehaviour {

	public MOVEMENTDIRECTION movementDirection { get; private set; }

	MOVEMENTDIRECTION lookingTo;

	public float speed = 0.05f;
	public float waitTimer = 0;
	public GameObject fire;
	GameObject b;

	void Start(){
		lookingTo = MOVEMENTDIRECTION.DOWN;
	}

	void Update()
	{	
		if (waitTimer > 0)
			waitTimer -= Time.deltaTime;
		else
			checkAction ();
	}

	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			movementDirection = MOVEMENTDIRECTION.UP;
			transform.position += new Vector3(0, speed, 0);
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			movementDirection = MOVEMENTDIRECTION.DOWN;
			transform.position += new Vector3(0, -speed, 0);
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			movementDirection = MOVEMENTDIRECTION.LEFT;
			transform.position += new Vector3(-speed, 0, 0);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			movementDirection = MOVEMENTDIRECTION.RIGHT;
			transform.position += new Vector3(speed, 0, 0);
		}
		else 
			movementDirection = MOVEMENTDIRECTION.NONE;
		
		if (movementDirection != MOVEMENTDIRECTION.NONE)
			lookingTo = movementDirection;

	}

	void checkAction(){
		if (Input.GetKey (KeyCode.Space)) {
			b = Instantiate (fire, transform.position, transform.rotation) as GameObject;
			
			FixedMove fm = b.GetComponent ("FixedMove") as FixedMove;
			fm.movementDirection = lookingTo;
			waitTimer = 0.5f;
			SetBulletOffset(lookingTo,b);
		}
	}
	
	static public void SetBulletOffset(MOVEMENTDIRECTION lookingTo, GameObject b) {
		switch (lookingTo) {
			case MOVEMENTDIRECTION.UP: 								
				b.transform.position += new Vector3 (0, 0.2f, 0);			
				break;
			case MOVEMENTDIRECTION.DOWN: 
				b.transform.position += new Vector3 (0.3f, -0.7f, 0);
				b.transform.Rotate (0, 0, 180);
				break;
			case MOVEMENTDIRECTION.LEFT: 
				b.transform.position += new Vector3 (-0.2f, -0.4f, 0);
				b.transform.Rotate (0, 0, 90);
				break;
			case MOVEMENTDIRECTION.RIGHT: 
				b.transform.position += new Vector3 (0.4f, -0.1f, 0);
				break;
		}
	}
}
