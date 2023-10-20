using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Citytogamecon : MonoBehaviour
{
    public float citytogame = 3.0f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = citytogame;
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("text");
            //timer = citytogame;
        }
    }

}
