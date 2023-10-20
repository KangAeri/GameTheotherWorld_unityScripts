using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    
    private SpriteRenderer sr;
    private Color originalColor;

    public float flashTime;
    public GameObject bloodEffect;
    private  PlayerHealth playerHealth;

    //public GameObject dropItem;

    private Animator anim;

    private float dieTime = 2f;



    public void start ()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        anim = GetComponent<Animator>();
       
    }


    public void  Update()
    {
        if (health <= 0)
        {
            //Instantiate(dropItem, transform.position, Quaternion.identity);
            anim.SetTrigger("death");
            this.GetComponent<BoxCollider2D>().enabled=false;
            Invoke("killEnemy", dieTime);
          

        }
        

    }
    void killEnemy()
    {
        Destroy(gameObject);
    }
    
    public void TakeDamage(int damage)
    {

        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        


    }
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        sr.color = originalColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject .CompareTag ("Player")&&other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if(playerHealth != null)
            {
                playerHealth.DamegePlayer(damage);
            }
           
        }
    }
}
