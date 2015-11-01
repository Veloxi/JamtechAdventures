using UnityEngine;
using System.Collections;

public class CharacterMelee : MonoBehaviour {

    //This script is considered an advanced script for Jamtech.
    // You don't have to use this at all! It
    // Can be added to a player if you want it to melee
    // Try to figure out the code for yourself!

    public float coolDown = .5f;
    public float meleeTime = .5f;
    public float meleeSpeed = 2f;

    //This must be set with a game object. it will be used 
    //as the endpoint for your melee that will hit the enemies to damage them
    public Transform meleeSpot;

    private float timer = 0f;
    private float meleeTimer = 0f;
    private bool attacking = false;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            if (timer <= 0) {
                attacking = true;
            }
        }
        timer -= Time.deltaTime;
        Attack();
    }

    void Attack() {
        if (attacking) {
            if (meleeTimer <= meleeTime) {
                LayerMask layer = (1 << 8);
                this.transform.position = new Vector2(this.transform.position.x + meleeSpeed * Time.deltaTime * this.transform.localScale.x, this.transform.position.y);
                if (Physics2D.Linecast(transform.position, meleeSpot.position, layer)) {
                    if (Physics2D.Linecast(transform.position, meleeSpot.position, layer)) {
                        GameObject enemy = Physics2D.Linecast(transform.position, meleeSpot.position, layer).collider.gameObject;
                        enemy.GetComponent<Health>().Damage(2);
                        attacking = false;
                        meleeTimer = 0;
                        GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, this.GetComponent<Rigidbody2D>().velocity.y);
                    }
                }
                meleeTimer += Time.deltaTime;
                timer = coolDown;
            } else {
                attacking = false;
                meleeTimer = 0;
            }
        }
    }
}
