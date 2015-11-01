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


        //sets the "layer" variable to the layer 0, which is the default layer in unity
		LayerMask layer = (1 << 0);

        //creates a line from the enemy's sight start towards the sight end position and checks if the layer is "layer" or what was just set to default.
        //and then checks if it is equal to ground
		if (Physics2D.Linecast (sightStart.position, sightEnd.position, layer) != ground) {
            //if it is reverse the scale of x, which rotates the enemy.
			this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0f);
		}
	}
}
