using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool itIsStillActiving;

    private void Update() {

        if(this.gameObject.activeSelf){
          itIsStillActiving = true;
        }
        if(itIsStillActiving){
            pauseMenu.SetActive(false);
        }
    }

    public void Setup(){
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void loadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void retry(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
