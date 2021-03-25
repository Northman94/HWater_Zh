using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    public SoundsStoringScript[] allSounds;


    //To Prevent duplicating/Cloning AudioManger due to DontDestroyOnLoad()
    public static AudioManagerScript instance;

    public static bool  sfxMuted = false;
    public static bool musicMuted = false;

    [SerializeField]
    private Toggle ToogleSFX;
    [SerializeField]
    private Toggle ToogleMusic;





    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // To ensure no more code executed before we destroyed gameObj
        }

        // Will prevent Music from restarting after Scene Load
        DontDestroyOnLoad(gameObject); 

        foreach (SoundsStoringScript _item in allSounds)
        {
            _item.aSource = gameObject.AddComponent<AudioSource>();

            _item.aSource.clip = _item.clip;

            _item.aSource.volume = _item.volume;

            _item.aSource.pitch = _item.pitch;

            _item.aSource.loop = _item.loop;
        } 
    }


    private void Start()
    {
        
        if (sfxMuted == false)
        {
            ToogleSFX.isOn = true;
        }

        if (musicMuted == false)
        {
            ToogleMusic.isOn = true;
        }
        

        PlayAudio("MainTheme");
    }


    public void PlayAudio(string _nameStart)
    {
        SoundsStoringScript startM = Array.Find(allSounds, sound => sound.name == _nameStart);

      

        if (_nameStart == null)
        {
            Debug.LogWarning("Sound " + name + " NOT found !!!"); //useful if you want know on which Obj a Warning occurs
            return;
        }

        if (musicMuted == false)
        {
            startM.aSource.Play();
        } 
    }


    public void StopAudio(string _nameStop)
    {
        SoundsStoringScript stopM = Array.Find(allSounds, sound => sound.name == _nameStop);


        stopM.aSource.Stop();
    }

    /*
    public void sfxLoadingFromSeconSceneState()
    {
        if (sfxMuted == false)
        {
            ToogleSFX.isOn = false;
        }
    }

    public void musicLoadingFromSeconSceneState()
    {
        if (musicMuted == false)
        {
            ToogleMusic.isOn = false;
        }
    }
    */

    public void sfxSwitch()
    {
        Debug.Log("SFX Switch");


        PlayAudio("SFXMusic");

        if (sfxMuted == false)
        {
            sfxMuted = true;
        }
        else
        {
            sfxMuted = false;
        }
    }

    public void musicSwitch()
    {
        Debug.Log("Music Switch");


        PlayAudio("SFXMusic");

        if (musicMuted == false)
        {
            StopAudio("MainTheme");
            musicMuted = true;
        }
        else
        {
            musicMuted = false;
            PlayAudio("MainTheme");
        }
    }

    public void PlaySounds()
    {
        if (sfxMuted == false)
        {
            PlayAudio("Play");
        }
    }

    public void SettingsSound()
    {
        if (sfxMuted == false)
        {
            PlayAudio("Settings");
        }
    }


    public void BackSound()
    {
        if (sfxMuted == false)
        {
            PlayAudio("Back");
        }
    }


    public void BackToMenu()
    {
        if (sfxMuted == false)
        {
            PlayAudio("BackToMenu");
        }
    }
}
