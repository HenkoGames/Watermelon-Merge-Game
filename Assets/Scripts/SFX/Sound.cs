using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> clips = new List<AudioClip>();
    void Start()
    {
        if (clips.Count > 0) source.clip = clips[Random.Range(0, clips.Count - 1)];
        source.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) 
        {
            Destroy(gameObject);
        }
    }
}
