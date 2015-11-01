using UnityEngine;
using System.Collections;

public class EnablePauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
	}
}
