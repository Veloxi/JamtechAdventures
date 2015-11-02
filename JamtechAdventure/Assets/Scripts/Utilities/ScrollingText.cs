using UnityEngine;
using System.Collections;

public class ScrollingText : MonoBehaviour {

    public float scrollSpeed;
    public float timeUntilSceneSwap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, GetComponent<RectTransform>().position.y+scrollSpeed, GetComponent<RectTransform>().position.z);
        timeUntilSceneSwap -= Time.deltaTime;
        
        if(timeUntilSceneSwap <= 0 || Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(1);
        }
	}
}
