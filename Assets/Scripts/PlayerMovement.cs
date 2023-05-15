using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Health and energy
    private float playerHealth = 300f;
    public float presentHealth;

    

    public PlayerHealthBar healthBar;

    public float movementSpeed;
    public float rotationSpeed = 300f;

    public Vector3 velocity;

    public CameraController MCC;

    Quaternion requredRotation;

    //Player Animator
    public Animator animator;

    //Player Controler
    public CharacterController cc;

    public GameOverScreen GameOverScreen;


    private void Awake()
    {
        Time.timeScale = 1f;
        presentHealth = playerHealth;
        healthBar.GiveFullHealth(presentHealth);
    }


    private void Update() {
        PlayerMovementMethod();
    }
    public void setSpeed(float speed)
    {
        movementSpeed = speed;
    }

    public void PlayerMovementMethod(){

        bool anyKeyPressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.Instance.playFoot();
        }
        else if (!anyKeyPressed)
        {
            AudioManager.Instance.stopFoot();
        }


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float movementAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        var movementInput = (new Vector3(horizontal,0, vertical)).normalized;

        var movementDirection = MCC.flatRotation * movementInput;

        if(movementAmount > 0){
            cc.Move(movementSpeed * movementDirection * Time.deltaTime);
            requredRotation = Quaternion.LookRotation(movementDirection);

        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, requredRotation, rotationSpeed * Time.deltaTime);

        animator.SetFloat("movementValue", movementAmount, 0.2f, Time.deltaTime);
        
        

    }

    public void playerHitDamage(float takeDamage)
    {
        presentHealth -= takeDamage;
        healthBar.setHealth(presentHealth);
        if(presentHealth <= 0)
        {
            PlayerDie();
        }
    }
    private void PlayerDie()
    {
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 1f);
        GameOverScreen.Setup();
    }

    public void healPlayer(){
        presentHealth = 200f;
    }
}
