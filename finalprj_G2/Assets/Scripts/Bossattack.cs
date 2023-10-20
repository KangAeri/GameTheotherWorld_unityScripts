using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossattack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bull;
    public Transform pos;
    public float cooltime;
    private float curtime;
    void Start()
    {
        curtime = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (curtime <= 0)
        {

            if (Input.GetKey(KeyCode.J))
            {
                Instantiate(bull, pos.position, transform.rotation);
            }
            curtime = cooltime;
            
        }
        curtime -= Time.deltaTime;
    }
}
