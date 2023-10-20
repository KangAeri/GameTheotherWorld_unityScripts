using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    private Animator anim;
    private PolygonCollider2D coll2D;
    public float time;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if(Input.GetButtonDown("Attack"))
        {
           
            anim.SetTrigger("attack");
            StartCoroutine(StartAttack ());
        }
        
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        coll2D.enabled = true;
        SoundManager.Instance.PlayAttackClip();
        StartCoroutine(disableHitBox());


    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("player attacked");
            other.GetComponent<Enemy >().TakeDamage(damage);
        }
    }
}
