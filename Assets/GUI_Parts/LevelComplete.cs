using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool itIsStillActiving;
    public LevelU level;

    private void Update() {

        if(this.gameObject.activeSelf){
          itIsStillActiving = true;
        }
        if(itIsStillActiving){
            pauseMenu.SetActive(false);
        }
    }

    public void Setup(){
        level.unlockLevel();
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void loadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void nextLevel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
