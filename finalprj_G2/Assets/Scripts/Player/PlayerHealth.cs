using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;


    public int blinks;
    public float time;
    public float dieTime;

    private Renderer myRender;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamegePlayer(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if (health <= 0)
        {
            anim.SetTrigger("die");
            Invoke("KillPlayer", dieTime);

        }
        BlinkPlayer(blinks, time);
    }
    void KillPlayer()
    {
        Destroy(gameObject);
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
    public void ChangeHealth(int amout)
    {
            Debug.Log("add health");

            //你这里之前的写法为什么不加血，因为你的mathf.clamp的值是当前生命值，而不是最大生命值，所以为什么不加血
        // health = Mathf.Clamp(health + amout, 0, health);
        
        health = Mathf.Clamp(health + amout, 0, HealthBar.HealthMax);

        //加完血之后 在对页面的UI进行一个更新.
        HealthBar.HealthCurrent = health;

    }
}
