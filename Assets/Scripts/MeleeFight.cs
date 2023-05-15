using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeFight : MonoBehaviour
{
    public int SingleMeleeVal;
    public Animator anim;
    public PlayerMovement PlayerMovement;
    public GameObject sword;

    public Transform attackArea;
    public float giveDamage = 20f;
    public float attackRadius;
    public LayerMask knightLayer;

    public bool isAllowed = true;

    void Update()
    {
        if (Input.GetKey("1"))
        {
            anim.SetBool("FistFightActive", false);
            anim.SetBool("SingleAttackActive", true);
            sword.SetActive(true);
            
            PlayerMovement.setSpeed(1f);
        }
        if (Input.GetKey("3"))
        {
            anim.SetBool("SingleAttackActive", false);
            sword.SetActive(false);
            PlayerMovement.setSpeed(3.5f);
        }
        if(isAllowed==false){
            StartCoroutine(WaitForInput());
        }
        MeleeFightModes();

    }

    void MeleeFightModes()
    {
        if (anim.GetBool("SingleAttackActive"))
        {
            if (Input.GetMouseButtonDown(0) && isAllowed == true)
            {
                isAllowed = false;
                SingleMeleeVal = Random.Range(1, 5);

                if (SingleMeleeVal == 1)
                {
                    Attack();
                    StartCoroutine(SingleAttack1());
                }
                if (SingleMeleeVal == 2)
                {
                    Attack();
                    StartCoroutine(SingleAttack2());
                }
                if (SingleMeleeVal == 3)
                {
                    Attack();
                    StartCoroutine(SingleAttack3());
                }
                if (SingleMeleeVal == 4)
                {
                    Attack();
                    StartCoroutine(SingleAttack4());
                }
                if (SingleMeleeVal == 5)
                {
                    Attack();
                    StartCoroutine(SingleAttack5());
                }
            }
        }
    }

    void Attack()
    {
        Collider[] hitEnemy = Physics.OverlapSphere(attackArea.position, attackRadius, knightLayer);

        foreach (Collider enemy in hitEnemy)
        {
            EnemyHealth ememyAI = enemy.GetComponent<EnemyHealth>();

            if (ememyAI != null)
            {
                ememyAI.TakeDamage(giveDamage);
                AudioManager.Instance.playSFX("Sword");
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackArea == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackArea.position, attackRadius);
    }


    IEnumerator SingleAttack1()
    {
        anim.SetBool("SingleAttack1", true);
        
        //PlayerMovement.setSpeed(0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack1", false);
        
        //PlayerMovement.setSpeed(1f);

    }
    IEnumerator SingleAttack2()
    {
        anim.SetBool("SingleAttack2", true);
        
        //PlayerMovement.setSpeed(0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack2", false);
        
        //PlayerMovement.setSpeed(1f);

    }
    IEnumerator SingleAttack3()
    {
        anim.SetBool("SingleAttack3", true);
        
        //PlayerMovement.setSpeed(0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack3", false);
        
        //PlayerMovement.setSpeed(1f);

    }
    IEnumerator SingleAttack4()
    {
        anim.SetBool("SingleAttack4", true);
        
        //PlayerMovement.setSpeed(0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack4", false);
        
        //PlayerMovement.setSpeed(1f);

    }
    IEnumerator SingleAttack5()
    {
        anim.SetBool("SingleAttack5", true);
        
        //PlayerMovement.setSpeed(0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack5", false);
        
        //PlayerMovement.setSpeed(1f);


    }

    private IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(2);
        isAllowed=true;
    }
}
