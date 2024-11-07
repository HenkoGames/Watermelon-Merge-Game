using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public GameObject pop;
    public GameObject clickSound1;
    public GameObject clickSound2;
    public GameObject clickSound3;
    public GameObject fail;
    public GameObject nextLevel;
    [Space]
    public AudioSource bgMusic;
    public void Awake()
    {
        instance = this;
    }
    public enum Sound{
        pop,
        click1,
        click2,
        click3,
        fail,
        nextLevel
    }
    public void PlaySound(Sound sound)
    {
        switch (sound)
        {
            case Sound.pop:
               Instantiate(pop);
                break;
            case Sound.click1:
                Instantiate(clickSound1);
                break;
            case Sound.click2:
                Instantiate(clickSound2);
                break;
            case Sound.click3:
                Instantiate(clickSound3);
                break;
            case Sound.fail:
                Instantiate(fail);
                break;
            case Sound.nextLevel:
                Instantiate(nextLevel);
                break; 
        }
    }
    public void PlaySound(string soundName)
    {
        if(Enum.TryParse(typeof(Sound),soundName, out var res))
        {
            PlaySound((Sound)res);
        }
        else
        {
            Debug.LogWarning($"No {soundName} sound in SoundManager");
        }
    }
    public void SetBgMusic(bool state)
    {
        if (state)
        {
            bgMusic.Play();
        }
        else
        {
            bgMusic.Stop();
        }
    }
}
