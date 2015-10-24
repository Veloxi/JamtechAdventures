using UnityEngine;
using System.Collections;

public class PlayerHealth : Health { 

    public AudioClip playerDamaged;

    public override void Damage(int amount) {
        health -= amount;
        if (health <= 0) {
            Application.LoadLevel(3);
        }
        GetComponent<AudioSource>().PlayOneShot(playerDamaged);
    }
}
