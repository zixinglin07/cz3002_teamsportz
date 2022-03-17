using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider backgroundSlider;
    //private float backgroundFloat;
    private GameObject PlayAudio;
    private AudioSource AudioSource;
    private PlayAudio test;
    
    // Start is called before the first frame update
    void Start()
    {
        //backgroundFloat = 1f;
        backgroundSlider.value = 1f;
        //PlayAudio = GameObject.FindGameObjectWithTag("Music");
        //Debug.Log(PlayAudio);
        //test = PlayAudio.GetComponent<PlayAudio>();
        //Debug.Log(test);
        //Debug.Log(test.AudioSource.volume);
        
     
        
    }

    public void UpdateSound()
    {
        PlayAudio = GameObject.FindGameObjectWithTag("Music");
        test = PlayAudio.GetComponent<PlayAudio>();
        //Debug.Log(test.AudioSource.volume);
        //Debug.Log(backgroundSlider.value);
        test.AudioSource.volume = backgroundSlider.value;
    }
}
