using UnityEngine;
using System.Collections;

public class CharacterMelee : MonoBehaviour {

    public float coolDown = .5f;
    public float meleeTime = .5f;
    public float meleeSpeed = 2f;
    public Transform meleeSpot;

    private float timer = 0f;
    private float meleeTimer = 0f;
    private bool attacking = false;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
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
                    if (Physics2D.Linecast(transform.position, meleeSpot.position, layer).collider.gameObject.tag == "Enemy") {
                        GameObject enemy = Physics2D.Linecast(transform.position, meleeSpot.position, layer).collider.gameObject;
                        enemy.GetComponent<Health>().Damage(2);
                        attacking = false;
                        meleeTimer = 0;
                        GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, this.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    // GetComponent<Rigidbody2D>().velocity = new Vector2()
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
