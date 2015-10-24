using UnityEngine;
using System.Collections;

public class DamagesPlayer : MonoBehaviour {

    public int damage;
    public float pushBackForce = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        LayerMask groundLayer = (1 << 8);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().Damage(damage);
            this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
            other.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-this.transform.localScale.x * pushBackForce, other.gameObject.GetComponent<CharacterShoot>().jumpForce));
        }
    }
}
