using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager instance;
    private static AudioSource caveMusic;
    private static AudioSource houseMusic;
    private static AudioSource currMusic;

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        houseMusic = GetComponents<AudioSource>()[0];
        caveMusic = GetComponents<AudioSource>()[1];
        currMusic = houseMusic;
        DontDestroyOnLoad(this.gameObject);
    }

    public static void changeMusic(string music) {
        if (music == "cave") {
            currMusic.Stop();
            caveMusic.Play();
            currMusic = caveMusic;
        }
        else if (music == "house") {
            currMusic.Stop();
            houseMusic.Play();
            currMusic = houseMusic;
        }
    }

    public static void playMenuMusic() {
        if (currMusic != houseMusic) {
            currMusic.Stop();
            houseMusic.Play();
            currMusic = houseMusic;
        }
    }
}
