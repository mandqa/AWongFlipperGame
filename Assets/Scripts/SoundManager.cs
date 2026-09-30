using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip target1Sound;

    public AudioClip target2Sound;
    public AudioClip target3Sound;
    public AudioClip flipperSound;
    public AudioClip launchSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonSound);
    }

    public void PlaySound1()
    {
        audioSource.PlayOneShot(target1Sound);
    }

    public void PlaySound2()
    {
        audioSource.PlayOneShot(target2Sound);
    }

    public void PlaySound3()
    {
        audioSource.PlayOneShot(target3Sound);
    }

    public void PlayFlipper()
    {
        audioSource.PlayOneShot(flipperSound);
    }

    public void PlayLaunch()
    {
        audioSource.PlayOneShot(launchSound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
