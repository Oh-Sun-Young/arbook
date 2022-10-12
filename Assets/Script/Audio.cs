using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    float timer;
    bool check;
    public AudioClip clipIntro;
    void Start()
    {
        timer = 0;
        check = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.5f && check)
        {
            check = false;
            GetComponent<AudioSource>().PlayOneShot(clipIntro);
        }
    }
}
