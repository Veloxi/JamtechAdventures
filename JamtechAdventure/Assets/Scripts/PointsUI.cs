using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour {

    public int playerPoints = 0;
    public Text pointText;

	// Use this for initialization
	void Start () {
        pointText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        pointText.text = "Score: " + playerPoints.ToString()+ "             Health: " + GetComponent<Health>().health;
	}
    void OnGUI() {

    }
}
