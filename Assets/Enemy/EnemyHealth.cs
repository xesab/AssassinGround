using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 200f;
    public float currentHealth;
    public Image healthBar;
    public Animator anim;
    public CharacterNavigatorScript knight1;
    public Character2Controller knight2;

    private void update()
    {
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        
        currentHealth -= amount;

        anim.SetTrigger("GetHit");
        

        healthBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0f)
        {
            AudioManager.Instance.playMusic("Death");
            Die();
        }
    }
    void Die()
    {
        StartCoroutine(DieObj());
        //Destroy(gameObject);
    }
    private IEnumerator DieObj()
    {
        if(knight1 != null){
            knight1.stop();
        }
        if(knight2 != null){
            knight2.stop();
        }
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
