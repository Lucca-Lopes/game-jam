using UnityEngine.Audio;
using UnityEngine;

public class MenuAudioSystem : MonoBehaviour {
    public AudioClip[] clips;
    private AudioSource source => GetComponent<AudioSource>();

    public void ButtonAudio(){
        source.clip = clips[0];
        source.pitch = 1;
        source.Play();
    }

    public void ButtonAudio2(){
        source.clip = clips[0];
        source.pitch = 2;
        source.Play();
    }

    public void Buy(bool canBuy) {
        if(canBuy){
            source.clip = clips[1];
            source.pitch = 1;
            source.Play();
        }else {
            source.clip = clips[2];
            source.pitch = 1;
            source.Play();
        }
    }

}
