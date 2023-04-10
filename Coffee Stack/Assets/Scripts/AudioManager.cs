using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pooring;
    public AudioClip packaging;
    public AudioClip takingCup;

    public static AudioManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }     
    }

    void Update()
    {

    }
}
