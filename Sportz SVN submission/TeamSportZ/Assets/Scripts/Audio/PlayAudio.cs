using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    private static PlayAudio instance = null;
    public static PlayAudio Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            AudioSource.Play();
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
