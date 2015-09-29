using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float projectileSpeed = 10f;
    public int damage = 1;
    public float timeOut = 3.0f;

    private float timer = 0f;

    // Use this for initialization

    void Update() {
        timer += Time.deltaTime;
        if(timer >= timeOut) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Enemy") {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                enemy.Damage(damage);
            }
            Destroy(this.gameObject);
        }
    }