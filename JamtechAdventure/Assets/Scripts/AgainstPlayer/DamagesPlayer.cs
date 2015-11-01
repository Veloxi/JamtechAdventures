using UnityEngine;
using System.Collections;

public class DamagesPlayer : MonoBehaviour {
    //This script should be added to anything that damages
    // the player when it hits the playeer

    // the amount of damage it will do
    public int damage;
    
    //how far the player will be pushed around by the damage
    public float pushBackForce = 50f;

    //the delay in between damaging the player
    // so the player does not get damaged every update
    private float delay = 0.5f;
    private float timer = 0f;

    void Update (){
        //updates the timer, or damage cooldown
        timer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if the player is ready to be damaged, and the player collides with this object
        if(other.collider.gameObject.tag == "Player" && timer < 0)
        {
            // the player's health is Damaged by the damage amount declared publicly at the
            //top of this script
            other.gameObject.GetComponent<Health>().Damage(damage);
            // this object is flipped around horizontally
            this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
            //the player gets a force added to them with their pushback force, and up with their jump height
            other.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-this.transform.localScale.x * pushBackForce, other.gameObject.GetComponent<CharacterShoot>().jumpForce));
            //reset the timer
            timer = delay;
        }
    }
}
