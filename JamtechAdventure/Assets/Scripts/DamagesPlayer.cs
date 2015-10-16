using UnityEngine;
using System.Collections;

public class DamagesPlayer : MonoBehaviour {

    public int damage;

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
        }
    }
}
