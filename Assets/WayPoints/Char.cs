using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    [Header("Character Info")]
    public float movingspeed;
    public float turningspeed = 300f;
    public float stopSpeed = 1f;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;

    public void update()
    {
        Walk();
    }
    
    public void Walk()
    {

        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;
        
        if (destinationDistance >= stopSpeed)
        {
            //Turning
            destinationReached = false;
            Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningspeed * Time.deltaTime);
            
            //Moving AI
            transform.Translate(Vector3.forward * movingspeed * Time.deltaTime);
        }
        else
        {
            destinationReached = true;
        }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
    
}
