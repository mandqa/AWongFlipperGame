using UnityEngine;
using System.Collections;

public class RandomEventManag : MonoBehaviour
{
    public Animator holeAnimator;

    public SpriteRenderer eventWheel;

    public Sprite event1;
    public Sprite event2;

    public Sprite event3;

    public Sprite event4;
    
    public ScoreManager scoreManager;

    int selectedEvent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EventLoop());
    }

    IEnumerator EventLoop()
    {
        while(true)
        {
            //wait 15 sec
            yield return new WaitForSeconds(15f);
            holeAnimator.Play("coverup");
            //wait for open hole anim
            yield return new WaitForSeconds(1f);
            //scroll through the events
            yield return StartCoroutine(SpinWheel());
            //event happens
            yield return new WaitForSeconds(5f);
            holeAnimator.Play("coverdown");
            //wait for close anim
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator SpinWheel()
    {
        float delay = 0.1f;
        
        for(int i = 0; i < 20; i++)
        {
            selectedEvent = Random.Range(1, 5);
            if (selectedEvent == 1)
            {
                eventWheel.sprite = event1;
            }
            else if (selectedEvent == 2)
            {
                eventWheel.sprite = event2;
            }
            else if (selectedEvent == 3)
            {
                eventWheel.sprite = event3;
            }
            else
            {
                eventWheel.sprite = event4;
            }

            //add 1k points to first event 
            if (selectedEvent == 1)
            {
                scoreManager.AddScore(1000);
            }
            yield return new WaitForSeconds(delay);

            delay += 0.03f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
