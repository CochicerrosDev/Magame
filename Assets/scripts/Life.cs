using UnityEngine;
using System.Collections;

public enum TYPE {
	PLAYER,
	MAGIC,
	ENEMY
}
public class Life : MonoBehaviour {

	public TYPE type;
	public int life = 50;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		Life otherLife = other.gameObject.GetComponent ("Life") as Life;
			
		// Si el objeto es de tipo magia y con el que choca es de tipo enemigo, hace daño 100
		if (type == TYPE.MAGIC && otherLife.type == TYPE.ENEMY) {
			otherLife.life -= 100;
		}
		// Si la vida del otro objeto esta por debajo de 0, se destruye
		if (otherLife.life <= 0)
			Destroy (other.gameObject);
		
		// Si es de tipo magia, se destruye al chocar con algo
		if(type == TYPE.MAGIC)
			Destroy (gameObject);
	
	}
}
