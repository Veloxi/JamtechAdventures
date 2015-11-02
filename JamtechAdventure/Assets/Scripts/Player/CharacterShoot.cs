using UnityEngine;
using System.Collections;

public class CharacterShoot : MonoBehaviour {

    //cooldown for the shoot
    public float coolDown = 0.5f;
    //speed of the projectile that you shoot
    public float projectileSpeed = 1f;
    //timer used for ensuring cooldown
    private float timer = 0f;

    //a spot from which you shoot, can be set with an empty game object
    public Transform shootSpot;
    //a reference to the projectile that you are supposed to shoot
    public GameObject projectile;
    //the players run speed
    public float runSpeed = 1.0f;
    //the upward force added to your jump
    public float jumpForce = 10.0f;
    // the bottom right point used for checking if there is ground below you
    public Transform groundCheckRight;
    //the bottom left point used for ground check
    public Transform groundCheckLeft;
    //the audio clips that the player uses, jump and shoot
    public AudioClip shootSound, jumpSound;

    //declares the animator
    private Animator animator;
    //declares the audioSource
    private AudioSource audioSource;

    //a boolean (true or false) value that is set by the GroundCheck
    // it must be true for you to be able to jump
    private bool onGround = true;

    // Use this for initialization
    void Start() {
        //ensures that the timescale of the game is set to 1
        Time.timeScale =     1f;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        //these methods are defined down below
        CheckForShoot();
        GroundCheck();
        Move();
        EnemyJumpCheck();
    }

    //Sets the ground value to see if you are able to 
    void GroundCheck() {
        //creates a layer variable and assigns it to layer 0
        LayerMask groundLayer = (1 << 0);
        //creates two lines, from player to the set ground check positions, if they intersect with something in layer 0,
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
        //If the key "A" is pressed,
        if (Input.GetKey(KeyCode.A)) {
            //Then Get the rigidbody2d of this object. Set its velocity to a new 2D vector with runspeed (negative for left) in the x (or left and right)
            //  direction (before the comma) and then we get the current velocity of this object's (the player's)  y(up and down) and
            // set it to the new velocity vector so we don't affect the up and down speed. 
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            //flips the player to the left
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1); ;
            if (onGround) {
                animator.SetInteger("AnimState", 1);
            }
        }
        //Repeat the above for D, the right direction. runSpeed is not negative this time
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            //flips the player to the right
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1); ;
            if (onGround) {
                animator.SetInteger("AnimState", 1);
            }
        }

        //The following code checks to make sure that if you are not pressing left and right and you are on the ground
        if (!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && onGround) {
            //then you will have 0 in the x and y velocity.
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.GetComponent<Rigidbody2D>().velocity.y);
            animator.SetInteger("AnimState", 0);
        }

        if (onGround) {
            if (Input.GetKeyDown(KeyCode.W)) {

                //To jump, we want to add force to the character's rigidbody in the y direction
                //AddForce DOES NOT set your velocity, it adds to it, so you do not need to get the current velocity for this 
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
                animator.SetInteger("AnimState", 2); 
   
                //plays the Characters set jump sound
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    //This method checks whether or not an enemy is 
    void EnemyJumpCheck() {
        LayerMask enemyLayer = (1 << 8); // assigns the layer you want to check for to layer 8 (which is assigned to "Enemy")

        //If, within a line between groundCheckLeft and groundCheckRight, there is something within the enemyLayer (an enemy)... also checks to make sure you are falling
        if (Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position, enemyLayer) && this.GetComponent<Rigidbody2D>() .velocity.y < 0) {
            //create an "enemy" variable
            GameObject enemy = Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position, enemyLayer).collider.gameObject;
            //get the health component of the enemy, and damage it
            enemy.GetComponent<Health>().Damage(2);
            //reverse the y velocity of the player, making it bounce back up.
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    //keeps track of the cooldown for shooting and shoots when you can
    void CheckForShoot() {
        //if you press Space and the timer <= 0
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0) {
            //create a projectile at the shootSpot.position with the shootSpot.rotation
            GameObject proj = (GameObject)Instantiate(projectile, shootSpot.position, shootSpot.rotation);
            //set the projectiles speed to the the variable projectile speed multiplied by your localscale.x (for direction)
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed * this.GetComponent<Transform>().localScale.x, 0f);
            //play the shoot sound
            audioSource.PlayOneShot(shootSound);
            //sets the timer back to the cooldown (resets the timer)
            timer = coolDown;
        }
        // subtract the change in time since the last update from the timer
        //this keeps track of the amount of time it has been since the last shot, 
        //since timer is set to the cooldown on the last shot
        timer -= Time.deltaTime;
    }
}
