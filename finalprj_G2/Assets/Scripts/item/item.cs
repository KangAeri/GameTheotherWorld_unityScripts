using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
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
        PlayerHealth pc = collision.GetComponent<PlayerHealth>();
        if (pc != null)
        {
           
           SoundManager.Instance.PlayCollectSound();
            pc.ChangeHealth(1);
            Destroy(gameObject);
        }
    }

}
