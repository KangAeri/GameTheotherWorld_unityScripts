using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmov : MonoBehaviour
{
    public float speed;
    public int bossdie;
    public bool vertical;
    public float changeTime = 6.0f;
    public int direction = 1;
    public int curhealth;
    public int maxhealth = 20;
    public GameObject dead;
    public GameObject ending;
    Rigidbody2D rigidbody2D;
    float timer;
    int loglife;
    public Bossbar bossbar;
    public Transform pos;

    public int damage;

    // Start is called before the first frame update

    void Start()
    {
        bossdie = 0;
        ending.SetActive(false);
        curhealth = maxhealth;
        bossbar.SetMaxHealth(maxhealth);
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 || rigidbody2D.position.x< -9.4f|| rigidbody2D.position.x > 10.0f)
        {
            direction = -direction;
            timer = changeTime;
        }
        


    }


    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x + Time.deltaTime * speed * direction; ;
        if (position.x < -9.4f)
        {
            position.x = -9.4f;
        }
        if(position.x > 10.0f)
        {
            position.x = 10.0f;
        }
        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "bullet")
        {
            //movmain player = other.gameObject.GetComponent<movmain>();
            Debug.Log("boss attacked");
            //if (player != null)
            //{
            ChangeHealth(-1);
            //}
            bossbar.SetHealth(curhealth);
        }
    }
    void ChangeHealth(int amount)
    {

        curhealth += amount;
        //currhealth = Mathf.Clamp(currhealth + amount, 0, maxhealth);
        Debug.Log(curhealth + "/" + maxhealth);
   
        //Bossbar.instance.SetValue(loglife / (float)maxhealth);
        if (curhealth < 0.0f)
        {
            //game success//gameover.gameObject.SetActive(true);
            
            Invoke("killEnemy", 0.1f);
            
        }

    }   
    void killEnemy(){
        Instantiate(dead, pos.position, transform.rotation);
        ending.SetActive(true);
        Destroy(gameObject);
       


    }
    void Damage(int damage)
    {
        curhealth -= damage;
    }
    
}
