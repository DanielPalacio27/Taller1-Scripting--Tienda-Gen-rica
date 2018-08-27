using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipController : MonoBehaviour {

    private static AudioClipController instance = null;
    public static AudioClipController Instance
    {
        get
        {
            return instance;
        }
    }

    public AudioClip audioBuyButton, consumeButton, changeWindow;
    public AudioSource audioSource;

	void Start () {

        audioSource = GetComponent<AudioSource>();

        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
	
}
