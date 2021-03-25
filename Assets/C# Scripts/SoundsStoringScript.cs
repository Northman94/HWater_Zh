using UnityEngine.Audio;
using UnityEngine;


//This will cause UnityEditor Inspector To show manageable list
[System.Serializable]
public class SoundsStoringScript
{
    //No need to derive this Class from MonoBehavior

    public string name;

    public AudioClip clip;

    [Range ( 0f, 1f )]
    public float volume;
    [Range ( .1f, 3f)]
    public float pitch;

    public bool loop;


    [HideInInspector]
    public AudioSource aSource;
}
