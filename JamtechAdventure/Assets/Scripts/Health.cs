using UnityEngine;
using System.Collections;

//This is the Health class. It goes on or is extended by any
// object in the world that should have a health amount
public class Health : MonoBehaviour {

    //public health amount, you can set this in the unity editor
    public int health = 10;
    
    public virtual void Damage(int amount) {
        //when the Damage method is called, and an amount of damage is passed to it, 
        // subtract that amount from the health
        health -= amount;
        
        if(health <= 0) {
            Destroy(this.gameObject);
        }
    }
}
