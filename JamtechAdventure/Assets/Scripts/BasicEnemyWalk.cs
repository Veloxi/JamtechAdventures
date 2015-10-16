using UnityEngine;
using System.Collections;

public class BasicEnemyWalk : MonoBehaviour {

	public float velocity = 5.0f;
	public Transform sightStart, sightEnd;
	public bool ground;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//keeps going back and forth, turning when it reaches the edge of a platform, or when it hits a wall
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * velocity, GetComponent<Rigidbody2D>().velocity.y);

		LayerMask layer = (1 << 8);
		if (Physics2D.Linecast (sightStart.position, sightEnd.position, layer) != ground) {
			this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0f);
		}
	}
}
