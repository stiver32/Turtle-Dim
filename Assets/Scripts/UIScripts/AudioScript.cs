using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]

    public AudioClip background;
    public AudioClip openMenuSound;
    public AudioClip closeMenuSound;
    public AudioClip clickButton;
    public AudioClip switchMenus;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);

    }

    // playerAudio.PlayOneShot(openMenuSound, 1.0f);
    //playerAudio.PlayOneShot(closeMenuSound, 1.0f);
    //    playerAudio.PlayOneShot(closeMenuSound, 1.0f);
    //     playerAudio.PlayOneShot(closeMenuSound, 1.0f);
    //    playerAudio.PlayOneShot(switchMenus, 1.0f);
    //    playerAudio.PlayOneShot(switchMenus, 1.0f);
    //     playerAudio.PlayOneShot(switchMenus, 1.0f);

}
