using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject MainMenuPannel, SettingsPannel, LevelPannel, AlertText, AlertText1;
    
    private void Start() {
        MainMenuPannel.SetActive(true);
        SettingsPannel.SetActive(false);
        LevelPannel.SetActive(false);
    }

    public void OpenSettingsPannel(){
        SettingsPannel.SetActive(true);
        MainMenuPannel.SetActive(false);
    }

    public void OpenLevelPannel(){
        LevelPannel.SetActive(true);
        MainMenuPannel.SetActive(false);
    }

    public void back(){
        SettingsPannel.SetActive(false);
        MainMenuPannel.SetActive(true);
        LevelPannel.SetActive(false);
    }
     
    public void quit(){
        Application.Quit();
    }

    public void resetLevels(){
        PlayerPrefs.SetFloat("Level2",0);
        StartCoroutine(alert1());
    }

    public bool checkUnlocked(string name){
        if(PlayerPrefs.GetFloat(name) == 1){
            return true;
        }else{
            return false;
        }
    }
    
    public void playLevel1(){
        SceneManager.LoadScene("Level_1");
    }
    
    public void playLevel2(){
        if(checkUnlocked("Level2")){
            SceneManager.LoadScene("Level_2");
        }else{
            StartCoroutine(alert());
        }
    }

    public void playLevel3(){
        if(checkUnlocked("Level3")){
            SceneManager.LoadScene("Level_3");
        }else{
            StartCoroutine(alert());
        }
    }

    IEnumerator alert(){
        AlertText.SetActive(true);
        yield return new WaitForSeconds(1f);
        AlertText.SetActive(false);
    }

    IEnumerator alert1(){
        AlertText1.SetActive(true);
        yield return new WaitForSeconds(1f);
        AlertText1.SetActive(false);
    }


}
