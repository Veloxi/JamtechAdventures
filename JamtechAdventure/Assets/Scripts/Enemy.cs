using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

<<<<<<< HEAD
	public int health;
	public int damageToPlayer;

=======
>>>>>>> origin/master
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

<<<<<<< HEAD
	void Damage(int damage)
	{
			health-=damage;
			if (health <= 0) {
				DestroyObject();
			}
	}
=======
    public void Damage(int damage) {
        //fill this later
    }
>>>>>>> origin/master
}
