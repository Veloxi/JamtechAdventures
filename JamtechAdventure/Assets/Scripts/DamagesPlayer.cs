using UnityEngine;
using System.Collections;

public class DamagesPlayer : MonoBehaviour {

    public int damage;
    public float pushBackForce = 50f;

    private float delay = 0.5f;
    private float timer = 0f;

    void Update (){
        timer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.gameObject.tag == "Player" && timer < 0)
        {
            other.gameObject.GetComponent<Health>().Damage(damage);
            this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
            other.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-this.transform.localScale.x * pushBackForce, other.gameObject.GetComponent<CharacterShoot>().jumpForce));
            timer = delay;
        }
    }
}
