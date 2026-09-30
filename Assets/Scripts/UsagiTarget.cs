using UnityEngine;

public class UsagiTarget : MonoBehaviour
{
   Animator anim;

   public SoundManager soundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            anim.SetTrigger("UsagiTarget");
            soundManager.PlaySound2();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
