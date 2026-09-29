using UnityEngine;

public class hachibell : MonoBehaviour
{
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            anim.SetTrigger("Ring");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
