using UnityEngine;
using System.Collections;

public class StartOverButton : MonoBehaviour {

    //method that makes the button do something when it's clicked
    public void startOver()
    {
        //loads the first level
        Application.LoadLevel(0);
    }
}
