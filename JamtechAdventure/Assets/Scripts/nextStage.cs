using UnityEngine;
using System.Collections;

public class nextStage : MonoBehaviour {
    int nextLevel;
	// Use this for initialization
	void Start () {
        nextLevel = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            Application.LoadLevel(nextLevel + 1);
        }
    }
}
