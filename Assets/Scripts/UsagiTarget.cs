using UnityEngine;

public class UsagiTarget : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent < Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            anim.SetTrigger("usagtar");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
