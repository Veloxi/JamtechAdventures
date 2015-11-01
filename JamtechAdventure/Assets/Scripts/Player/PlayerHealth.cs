using UnityEngine;
using System.Collections;

//this is a Health bar specific to the player. it extends "Health"
public class PlayerHealth : Health { 
    //extending health means that all of the methods and variables inside of Health
    // can be called within this class, and anything that gets the "Health" component
    // of the player will point to this script as well

    // public reference to the sound the player makes when damaged
    public AudioClip playerDamaged;

    //the override key word is used here to specify that for the PlayerHealth script
    // we will use this method instead of the Damage method that it could have 
    // inherited from "Health"
    public override void Damage(int amount) {
        health -= amount;
        if (health <= 0) {
            //if the players health gets to zero, load the death scene
            Application.LoadLevel(3);
        }
        //adds the sound whenever the player is damaged
        GetComponent<AudioSource>().PlayOneShot(playerDamaged);
    }
}
