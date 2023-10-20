using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public float timeToDestroy;
    void start()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void Update()
    {
        
    }
}
