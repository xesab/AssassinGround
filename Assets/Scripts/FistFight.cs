using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistFight : MonoBehaviour
{
    public float timer = 0f;
    public int FistFightVal;
    public Animator anim;
    public GameObject sword;
    public PlayerMovement playerMovement;

    public Transform attackArea;
    public float giveDamage = 10f;
    public float attackRadius;
    public LayerMask knightLayer;

    [SerializeField] Transform LeftHandPunch;
    [SerializeField] Transform RightHandPunch;
    [SerializeField] Transform LeftLegKick;

    public bool isAllowed = true;
    

    void Update()
    {
        if (Input.GetKey("2"))
        {
            anim.SetBool("SingleAttackActive", false);
            anim.SetBool("FistFightActive", true);
            sword.SetActive(false);
            
            playerMovement.setSpeed(2f);
        }
        if(Input.GetKey("3"))
        {
            anim.SetBool("FistFightActive", false);
            playerMovement.setSpeed(3.5f);
        }
        if(isAllowed==false){
            StartCoroutine(WaitForInput());
        }

        FistFightModes();

    }

    void FistFightModes()
    {
        if(anim.GetBool("FistFightActive"))
        {
            if (Input.GetMouseButtonDown(0) && isAllowed == true)
            {
                isAllowed = false;
                FistFightVal = Random.Range(1, 5);

                if (FistFightVal == 1)
                {
                    attackArea = LeftHandPunch;
                    attackRadius = 0.5f;
                    Attack();
                    StartCoroutine(SingleFist());
                    
                }
                if (FistFightVal == 2)
                {
                    attackArea = RightHandPunch;
                    attackRadius = 0.6f;
                    Attack();
                    StartCoroutine(DoubleFist());
                    
                }
                if (FistFightVal == 3)
                {
                    attackArea = LeftHandPunch;
                    attackArea = LeftLegKick;
                    attackRadius = 0.7f;
                    Attack();
                    StartCoroutine(Kick());
                    
                }
                if (FistFightVal == 4)
                {
                    attackArea = LeftLegKick;
                    attackRadius = 0.9f;
                    Attack();
                    StartCoroutine(KickCombo());
                    
                }
                if (FistFightVal == 5)
                {
                    attackArea = LeftLegKick;
                    attackRadius = 0.9f;
                    Attack();
                    StartCoroutine(LeftKick());
                    
                }
            }
        }
    }

    void Attack()
    {
        Collider[] hitEnemy = Physics.OverlapSphere(attackArea.position, attackRadius, knightLayer);

        foreach(Collider enemy in hitEnemy)
        {
            EnemyHealth ememyAI = enemy.GetComponent<EnemyHealth>();
            
            if(ememyAI != null)
            {
                ememyAI.TakeDamage(giveDamage);
                AudioManager.Instance.playSFX("Punch");
             
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackArea == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackArea.position, attackRadius);
    }


    IEnumerator SingleFist()
    {
        anim.SetBool("SingleFist", true);
        
        playerMovement.setSpeed(0f);
        anim.SetFloat("movementValue",0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("SingleFist", false);
        
        playerMovement.setSpeed(2f);
        anim.SetFloat("movementValue",0f);

    }
    IEnumerator DoubleFist()
    {
        anim.SetBool("DoubleFist", true);
        
        playerMovement.setSpeed(0f);
        anim.SetFloat("movementValue",0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("DoubleFist", false);
        
        playerMovement.setSpeed(2f);
        anim.SetFloat("movementValue",0f);

    }
    IEnumerator Kick()
    {
        anim.SetBool("Kick", true);
        
        playerMovement.setSpeed(0f);
        anim.SetFloat("movementValue",0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Kick", false);

        playerMovement.setSpeed(2f);
        anim.SetFloat("movementValue",0f);

    }
    IEnumerator KickCombo()
    {
        anim.SetBool("KickCombo", true);
        
        playerMovement.setSpeed(0f);
        anim.SetFloat("movementValue",0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("KickCombo", false);
        
        playerMovement.setSpeed(2f);
        anim.SetFloat("movementValue",0f);

    }
    IEnumerator LeftKick()
    {
        anim.SetBool("LeftKick", true);
        
        playerMovement.setSpeed(0f);
        anim.SetFloat("movementValue",0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("LeftKick", false);
        
        playerMovement.setSpeed(2f);
        anim.SetFloat("movementValue",0f);

    }

    private IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(2);
        isAllowed=true;
    }
}
