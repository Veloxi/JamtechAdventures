using UnityEngine;
using System.Collections;

public class CharacterShoot : MonoBehaviour {

    public float coolDown = 0.5f;
    public float projectileSpeed = 1f;
    private float timer = 0f;

    public Transform shootSpot;
    public GameObject projectile;
    public float runSpeed = 1.0f;
    public float jumpForce = 10.0f;
    public Transform groundCheckRight;
    public Transform groundCheckLeft;

    private Animator animator;

    public bool onGround = true;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        GroundCheck();
        Move();
        EnemyJumpCheck();
        CheckForShoot();
    }

    //Sets the ground value to see if you are able to 
    void GroundCheck() {
        //creates a layer variable and assigns it to layer 8
        LayerMask groundLayer = (1 << 8);
        //creates two lines, from player to the set ground check positions, if they intersect with something with layer 8,
        // changes onground to true
        if (Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position, groundLayer)) {
            //draws lines that only show up in scene view
            Debug.DrawLine(groundCheckRight.position, groundCheckLeft.position, Color.green);
            onGround = true;
        } else {
            //draws lines that only show up in scene view
            Debug.DrawLine(groundCheckRight.position, groundCheckLeft.position, Color.red);
            onGround = false;
        }


    }

    //The basic movement functions of the character
    void Move() {
        if (GetComponent<Rigidbody2D>().velocity.x == 0)
            animator.SetInteger("AnimState", 0);
        //If the key "A" is pressed,
        if (Input.GetKey(KeyCode.A)) {
            //Then Get the rigidbody2d of this object. Set its velocity to a new 2D vector with runspeed (negative for left) in the x (or left and right)
            //  direction (before the comma) and then we get the current velocity of this object's (the player's)  y(up and down) and
            // set it to the new velocity vector so we don't affect the up and down speed. 
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1); ;
            animator.SetInteger("AnimState", 1);
        }
        //Repeat the above for D, the right direction. runSpeed is not negative this time
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1); ;
            animator.SetInteger("AnimState", 1);
        }
        if (!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && onGround) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.GetComponent<Rigidbody2D>().velocity.y);
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
        LayerMask layer = (1 << 8);
        if (Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position, layer)) {
            if (Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position, layer).collider.gameObject.tag == "Enemy") {
                GameObject enemy = Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position, layer).collider.gameObject;
                enemy.GetComponent<Health>().Damage(2);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
    void CheckForShoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(timer <= 0) {
                animator.SetInteger("AnimState", 3);
                GameObject proj;
                proj = (GameObject)Instantiate(projectile, shootSpot.position, shootSpot.rotation);
                proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed * this.GetComponent<Transform>().localScale.x, 0f);
                timer = coolDown;
            }
        }
        timer -= Time.deltaTime;
    }
}
