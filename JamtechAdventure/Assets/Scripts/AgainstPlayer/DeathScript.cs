using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

    // This simple script will take the health of any object that has health on it to zero
    // when the object passes through a trigger box
    void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<Health>().Damage(other.gameObject.GetComponent<Health>().health);
    }
}
