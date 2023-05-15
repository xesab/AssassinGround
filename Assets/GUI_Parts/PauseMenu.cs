using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused == true){
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause(){
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void loadMenu(){
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");

    }
    public void quit(){
        Application.Quit();
    }
}
