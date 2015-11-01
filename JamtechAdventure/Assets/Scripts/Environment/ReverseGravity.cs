using UnityEngine;
using System.Collections;

public class ReverseGravity : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }
}
