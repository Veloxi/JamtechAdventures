using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public PointsUI pointsUI;
    public AudioClip collect;


    void Start() {
        GameObject playerPlayer = GameObject.FindWithTag("Player");
        pointsUI = playerPlayer.GetComponent<PointsUI>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pointsUI.playerPoints += 10;
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(collect, 1f); 
        }
        Destroy(this.gameObject);
    }

}
