using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public PointsUI pointsUI;


    void Start() {
        GameObject playerPlayer = GameObject.FindWithTag("Player");
        pointsUI = playerPlayer.GetComponent<PointsUI>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pointsUI.playerPoints += 10;
        }
        Destroy(this.gameObject);
    }

}
