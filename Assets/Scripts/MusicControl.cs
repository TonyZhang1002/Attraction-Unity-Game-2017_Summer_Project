using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

    private AudioSource bgm;

    void Start () {
        bgm = GetComponent<AudioSource>();
        bgm.volume = 0.5f;
    }

    public void VolumeChanged(float newVolume)
    {
        bgm.volume = newVolume;
    }

    void Update () {
		
	}
}
