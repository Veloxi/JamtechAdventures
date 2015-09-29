using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int health;
	public int damageToPlayer;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Damage(int damage)
	{
		health-=damage;
		if (health <= 0) {
			Destroy(GetComponent<GameObject>());
		}
	}
}
