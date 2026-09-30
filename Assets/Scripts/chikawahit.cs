using UnityEngine;

public class chikawahit : MonoBehaviour
{
    Animator myAnimator;

    public AudioSource chikawa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            myAnimator.SetTrigger("chikawahit");
            chikawa.Play();
        }
    }
}
