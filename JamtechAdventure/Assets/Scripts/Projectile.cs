using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float projectileSpeed = 10f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag = "Enemy") {
            ()
        }
    }
}
