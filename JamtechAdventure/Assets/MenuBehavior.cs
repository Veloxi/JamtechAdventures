using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

    public GameObject camera;
    public GameObject credits;
    public GameObject thatCanvas;

    public Text openingCreditText;
    public string place;
    public string villain;
    public string event1;
    public string hero;
    public string power;

    public bool cameraMove = true;
    public bool creditTextMove = true;

    public float countdown = 6.0f;
    public int creditScrollSpeed;

	// Use this for initialization
	void Start () {
        
	    openingCreditText.text = "Long ago in the far away land of " + place + " the tyrannical " + villain + " came to power when " + event1 + ".                                                                               The people lived in terror until one day " + hero + " set out to set right the wrongs of " + villain + " and restore order to " + place + ". With their power of " + power + ", can " + hero + " save the world?";
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraMove == true) {
            camera.transform.Translate(Vector3.down * Time.deltaTime);
            credits.transform.Translate(Vector3.up * creditScrollSpeed * Time.deltaTime);
        }

        if (countdown <= 0) {
            cameraMove = false;
            thatCanvas.SetActive(true);
        }

        countdown -= 1 * Time.deltaTime;
	}

   // void OnCollisionEnter2D(Collision2D other) {
     //   if (other.gameObject.tag == "stopper") {
       //     cameraMove = false;
        //}
    //}

    public void Play() {
        Application.LoadLevel(1);
    }

    public void Quit() {
        Application.Quit();
    }
}
