using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    //method that the button will do when it's clicked
	public void exitGame()
    {
        //closes game
        Application.Quit();
    }
}
