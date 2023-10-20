using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

           SoundManager.Instance.PlayCollectSound();
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.SpeedDown();
            }
            Destroy(gameObject);
            // if (pc != null)
            // {

            //     pc.ChangeHealth(1);
            //     Destroy(gameObject);
            // }
        }
    }
}
