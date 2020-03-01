using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] songFiles;
    bool isNext = false;
    AudioSource playMe;
    public static SoundManager instance;
    public AudioClip[] otherSounds;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
        playMe = GetComponent<AudioSource>();
        StartCoroutine(PlaySong());
    }
    public void playAtLocSound(float x, float y, string sound)
    {
        GameObject tmp = new GameObject();
        tmp.AddComponent<AudioSource>();
        for (int i = 0; i < otherSounds.Length; i++)
            if (otherSounds[i].name == sound)
                tmp.GetComponent<AudioSource>().clip = otherSounds[i];
        tmp.AddComponent<TemporarySoundObject>();
        Instantiate(tmp, new Vector2(x, y), Quaternion.identity);
    }
    void playRandom()
    {
        StopCoroutine(PlaySong());
        isNext = false;
        StartCoroutine(PlaySong());
    }
    void playNext()
    {
        StopCoroutine(PlaySong());
        isNext = true;
        StartCoroutine(PlaySong());
    }

    private IEnumerator PlaySong(int i = -1)
    {
        if (i == -1)
            i = Random.Range(0, songFiles.Length);
        playMe.clip = songFiles[i];
        playMe.Play();
        yield return new WaitForSeconds(songFiles[i].length);
        if(isNext)
            i = (i + 1)%songFiles.Length;
        else
            i = Random.Range(0, songFiles.Length);
    }
}
