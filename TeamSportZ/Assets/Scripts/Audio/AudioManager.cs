using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider backgroundSlider;
    private float backgroundFloat;
    private static readonly string firstPlay = "firstPlay";
    private static readonly string backgroundPref = "backgroundPref";

    private GameObject PlayAudio;
    private AudioSource AudioSource;
    private PlayAudio test;
    private int firstPlayInt;
    public static AudioManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);
        if (firstPlayInt == 0)
        {
            backgroundFloat = .5f;
           backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
           backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
            backgroundSlider.value = backgroundFloat;
        
        }

        //backgroundFloat = 1f;
        //backgroundSlider.value = 1f;
        //PlayAudio = GameObject.FindGameObjectWithTag("Music");
        //Debug.Log(PlayAudio);
        //test = PlayAudio.GetComponent<PlayAudio>();
        //Debug.Log(test);
        //Debug.Log(test.AudioSource.volume);
        
     
        
    }
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(backgroundPref, backgroundSlider.value);
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
