using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelU : MonoBehaviour
{
    public int Level;
    public void unlockLevel(){
        PlayerPrefs.SetFloat("Level"+Level,1);
    }
}
