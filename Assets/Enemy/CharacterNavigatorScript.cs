using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigatorScript : MonoBehaviour
{
    [Header("Character Info")]
    public float movingSpeed;
    public float runningSpeed;
    public float currentSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;

    [Header("Knight AI")]
    public GameObject playerBody;
    public LayerMask playerLayer;
    public float visionRadius;
    public bool playerInvisionRadius;
    public float attackRadius;
    public bool playerInattackRadius;

    [Header("Knight attack Variables")]
    public int SingleMeleeVal;
    public Transform attackArea;
    public float giveDamage;
    public float attackingRadius;
    bool previouslyAttack;
    public float timebtwAttack;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movingSpeed = 1.2f;
        runningSpeed = 2f;
        currentSpeed = movingSpeed;
        playerBody = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        playerInattackRadius = Physics.CheckSphere(transform.position, attackRadius, playerLayer);

        if (!playerInvisionRadius && !playerInattackRadius)
        {
            anim.SetBool("Idle", false);
            Walk();
        }

        if (playerInvisionRadius && !playerInattackRadius)
        {
            anim.SetBool("Idle", false);
            ChasePlayer();
        }

        if (playerInvisionRadius && playerInattackRadius)
        {
            anim.SetBool("Idle", true);
            SingleMeleeModes();
        }
        

    }

    public void Walk()
    {   
        anim.SetBool("Run", false);
        anim.SetBool("Walk", true);
        currentSpeed = movingSpeed;
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
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);
                //Moving AI
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
                
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

    public void ChasePlayer()
    {
        currentSpeed = runningSpeed;
        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        transform.LookAt(playerBody.transform);
        anim.SetBool("Attack", false);
        anim.SetBool("Run", true);
    }

    void SingleMeleeModes()
    {
        anim.SetBool("Attack",true);
            if (!previouslyAttack)
            {
                SingleMeleeVal = Random.Range(1, 4);

                if (SingleMeleeVal == 1)
                {
                    Attack();
                    StartCoroutine(Attack1());
                }
                if (SingleMeleeVal == 2)
                {
                    Attack();
                    StartCoroutine(Attack2());
                }
                if (SingleMeleeVal == 3)
                {
                    Attack();
                    StartCoroutine(Attack3());
                }
                if (SingleMeleeVal == 4)
                {
                    Attack();
                    StartCoroutine(Attack4());
                }
            }
    }
    void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackArea.position, attackingRadius, playerLayer);

        foreach (Collider player in hitPlayer)
        {
            PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
            if (playerScript != null)
            {
                playerScript.playerHitDamage(giveDamage);
            }
            
        }
        previouslyAttack = true;
        Invoke(nameof(ActiveAttack), timebtwAttack);

    }
    private void OnDrawGizmosSelected()
    {
        if(attackArea == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackArea.position, attackingRadius);
    }

    public void ActiveAttack()
    {
        previouslyAttack = false;
    }

    IEnumerator Attack1()
    {
        anim.SetBool("Attack1", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack1", false);
        movingSpeed = 1.2f;
        runningSpeed = 2.5f;
    }
    IEnumerator Attack2()
    {
        anim.SetBool("Attack2", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack2", false);
        movingSpeed = 1.2f;
        runningSpeed = 2.5f;
    }
    IEnumerator Attack3()
    {
        anim.SetBool("Attack3", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack3", false);
        movingSpeed = 1.2f;
        runningSpeed = 2.5f;
    }
    IEnumerator Attack4()
    {
        anim.SetBool("Attack4", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack4", false);
        movingSpeed = 1.2f;
        runningSpeed = 2.5f;
    }

    public void stop(){
        visionRadius = 0;
    }
}
