using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour {

    //starts the player's points at zero
    public int playerPoints = 0;
    //declares a text field
    public Text pointText;

	
	void Start () {
        //initializes the text field to an empty string
        pointText.text = "";
	}
	
	
	void Update () {
        // sets the text to "Score:    (playerPoints)     Health: (players health)"
        pointText.text = "Score: " + playerPoints.ToString()+ "             Health: " + GetComponent<Health>().health;
	}
}
