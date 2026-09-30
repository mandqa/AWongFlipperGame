using UnityEngine;
using System.Collections;

public class MusicFade : MonoBehaviour
{
    public AudioSource bg;
    
    public float startVolume = 0.8f;
    public float targetVolume = 0.1f;

    public float fadeTime = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bg.volume = startVolume;
        StartCoroutine(FadeDown());
    }

    IEnumerator FadeDown()
    {
        float time = 0f;
        while (time < fadeTime)
        {
            bg.volume = Mathf.Lerp(startVolume, targetVolume, time/fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        bg.volume = targetVolume;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
