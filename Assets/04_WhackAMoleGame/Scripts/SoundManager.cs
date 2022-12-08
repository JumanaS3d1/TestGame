using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource smashSound = null;
    public AudioSource whistle = null;

    void Awake()
    {
        Instance = this;
    }

}
