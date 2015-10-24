using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<Health>().Damage(other.gameObject.GetComponent<Health>().health);
    }
}
