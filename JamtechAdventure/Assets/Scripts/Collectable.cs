using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public PointsUI pointsUI;


    void Start() {
        GameObject playerPlayer = GameObject.FindWithTag("Player");
        pointsUI = playerPlayer.GetComponent<PointsUI>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            pointsUI.playerPoints += 10;
        }
        Destroy(this.gameObject);
    }

}
