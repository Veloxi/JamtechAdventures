using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    //Script to make the camera follow the player.
    //use the public floats for the camera offset.

    public float xOffset;
    public float yOffset;

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        //makes the Camera move to the players position, + the offsets in either direction
        this.transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, -10f);
	}
}
