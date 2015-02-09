using UnityEngine;
using System.Collections;

public class PursuingEnemy : MonoBehaviour {

	GameObject player;
	public float speed = 0.03f;

	void Start () {	
		player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
	}
}
