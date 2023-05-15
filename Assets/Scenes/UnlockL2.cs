using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockL2 : MonoBehaviour
{
    public void unlockL2(){
        PlayerPrefs.SetFloat("Level2",1);
    }
}
