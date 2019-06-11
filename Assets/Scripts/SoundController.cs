using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

    public static SoundController Instance;
    public bool Sound;
    public GameObject music;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    public float volume;
    bool repeat;

    void Awake()
    {
        repeat = true;
        if(Sound)
        {
            volume = 0f;
            volume = PlayerPrefs.GetFloat("Sound");
        }

        Instance = this;
        
        music.GetComponent<AudioSource>().volume = 0.2f;
        
        

    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }

    void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
        
    }

    public void ShowSliderValue()//вызывается при изменении значений слайдера
    {
        if (Sound)
        {
            PlayerPrefs.SetFloat("Sound", music.GetComponent<AudioSource>().volume);//если звук, записывается значение с ключом SLVL
        }
    }
        // Use this for initialization
    void Start () {
        music.GetComponent<AudioSource>().volume = 0.5f;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
