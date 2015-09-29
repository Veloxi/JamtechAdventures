using UnityEngine;
using System.Collections;

public class CharacterBasic : MonoBehaviour {

    public float runSpeed = 1.0f;
    public float jumpForce = 10.0f;
    public Transform groundCheckRight;
    public Transform groundCheckLeft;
    public Transform downCheck;

    public bool onGround = true;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        GroundCheck();
        Move();
        EnemyJumpCheck();
    }

    //Sets the ground value to see if you are able to 
    void GroundCheck() {
        //creates a layer variable and assigns it to layer 8
        LayerMask groundLayer = (1 << 8);
        //creates two lines, from player to the set ground check positions, if they intersect with something with layer 8,
        // changes onground to true
        if (Physics2D.Linecast(transform.position, groundCheckLeft.position, groundLayer)
            || Physics2D.Linecast(transform.position, groundCheckRight.position, groundLayer)) {
            onGround = true;
        } else {
            onGround = false;
        }

        //draws lines that only show up in scene view
        Debug.DrawLine(transform.position, groundCheckLeft.position, Color.white);
        Debug.DrawLine(transform.position, groundCheckRight.position, Color.white);
    }

    //The basic movement functions of the character
    void Move() {
        //If the key "A" is pressed,
        if (Input.GetKey(KeyCode.A)) {
            //Then Get the rigidbody2d of this object. Set its velocity to a new 2D vector with runspeed (negative for left) in the x (or left and right)
            //  direction (before the comma) and then we get the current velocity of this object's (the player's)  y(up and down) and
            // set it to the new velocity vector so we don't affect the up and down speed. 
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1); ;
        }
        //Repeat the above for D, the right direction. runSpeed is not negative this time
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1); ;
        }

        if (onGround) {
            if (Input.GetKeyDown(KeyCode.W)) {

                //To jump, we want to add force to the character's rigidbody in the y direction
                //AddForce DOES NOT set your velocity, it adds to it, so you do not need to get the current velocity for this 
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
            }
        }
    }

    void EnemyJumpCheck() {
        LayerMask enemyLayer = (1 << 9);
        if (Physics2D.Linecast(transform.position, downCheck.position, enemyLayer)){
            GameObject enemy = Physics2D.Linecast(transform.position, downCheck.position, enemyLayer).collider.gameObject;
            enemy.GetComponent<Health>().Damage(2);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x);
        }
        Debug.DrawLine(this.transform.position, downCheck.position, Color.red);

    }
}
