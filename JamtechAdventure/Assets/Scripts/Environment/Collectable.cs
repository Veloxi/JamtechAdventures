using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    //a reference to the pointsUI, so that we can display the points the player has
    public PointsUI pointsUI;
    // a reference to the audio clip collect sound
    public AudioClip collect;


    void Start() {
        //create a variable player, by finding a game object that is tagged "Player"
        GameObject player = GameObject.FindWithTag("Player");
        //sets the pointsUI to the PointsUI component of the player
        pointsUI = player.GetComponent<PointsUI>();
    }

    //When something moves through the collectible (assuming it has a trigger collider on it)
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the other object is tagged "Player"
        if (other.tag == "Player")
        {
            //get the playerPoints variable inside of the PointsUI script and add 10 to it
            pointsUI.playerPoints += 10;
            // get the audio source inside of the player game object and play the collect sound through it
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(collect, 1f);
            Destroy(this.gameObject);
        }
        
    }

}
