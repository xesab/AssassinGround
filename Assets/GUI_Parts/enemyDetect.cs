using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDetect : MonoBehaviour
{
    public LevelComplete LevelComplete;
    void Update()
    {
        // Detect enemy layered objects
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1000);
        bool enemyDetected = false;
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyDetected = true;
                break;
            }
        }

        if (enemyDetected)
        {

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("All Enemies have been Killed");
            LevelComplete.Setup();
        }
    }
}
