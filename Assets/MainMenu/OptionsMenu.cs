using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeSound(float valSound) {
        audioMixer.SetFloat("VolumeSound", valSound);
    }

    public void SetVolumeMusic(float valMusic)
    {
        audioMixer.SetFloat("VolumMusic", valMusic);
    }
}
