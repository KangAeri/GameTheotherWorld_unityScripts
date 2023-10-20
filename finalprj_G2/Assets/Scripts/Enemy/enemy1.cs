using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : Enemy 
{

    public float speed;
    public float startWaitTime;
    private float waitTime;
    

    public Transform movePos;
    public Transform LeftDownPos;
    public Transform RightUpPos;

    public float dieTime;



    public void Start()
    {
        base.start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        
    }


    public void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if(Vector2 .Distance (transform .position ,movePos .position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
 
    Vector2  GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(LeftDownPos.position.x, RightUpPos.position.x),Random .Range (LeftDownPos .position .y,RightUpPos .position .y ));
        return rndPos;
    }
}
