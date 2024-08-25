using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSound : MonoBehaviour
{
    PushedButton_TrickPattern pushedButton_TrickPattern;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pushedButton_TrickPattern=GetComponent<PushedButton_TrickPattern>();
        audioSource=GetComponent<AudioSource>();
    }

    public void SoundEffect()//トリックの効果音の再生
    {
        AudioClip soundEffect = pushedButton_TrickPattern.CurrentTrickPattern.SoundEffect;
        audioSource.PlayOneShot(soundEffect);
    }
}
