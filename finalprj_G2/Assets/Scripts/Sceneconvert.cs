using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Sceneconvert : MonoBehaviour
{
    public float gametocity = 6.0f;

   
    
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gametocity;

    }

    // Update is called once per frame

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("city2");
            //timer = gametocity;

        }
        
    }
}
