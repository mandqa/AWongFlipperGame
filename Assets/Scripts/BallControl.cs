using UnityEngine;
using UnityEngine.InputSystem;

public class BallControl : MonoBehaviour
{
    InputAction launchButton;

    Rigidbody2D myBody; 
    public InputActionAsset inputActions;
    public Animator launcherAnimator;
    public Animator gateAnimator;
    float pressTime = 0f;

    bool hasLaunched = false;

    public float pressMax;

    public float launchForce = 1000f;

    Vector2 resetPosition;

    float resetDelay = 0.3f;
    bool resetting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        launchButton = InputSystem.actions.FindAction("Player/Launch");
        resetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //when ball hasnt been launched
        if (!hasLaunched && !resetting)
        {
            //hold space to build power
            if (launchButton.IsPressed() && pressTime < pressMax)
            {
                //returns time in seconds to complete last frame
                pressTime += Time.deltaTime;
                launcherAnimator.SetBool("Charging", true);
            }

            //released frame
            if (launchButton.WasReleasedThisFrame())
            {
                launcherAnimator.SetBool("Charging", false);
                Launchball();
            }
        }

    }

    void Launchball()
    {
        float launchPower = launchForce * pressTime;
        myBody.AddForce(Vector2.up * launchPower);
        hasLaunched = true;
        //gate go down
        gateAnimator.SetBool("Gate", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Reset") && !resetting)
        {
            resetting = true;
            hasLaunched = false;

            Invoke("ResetBall", resetDelay);
        }
    }
    //gives it so the ball has a little delay time rather then teleporting immediately
    void ResetBall()
    {
            //stop the ball
            myBody.linearVelocity = Vector2.zero;
            myBody.angularVelocity = 0f;
            
            //put it back at the launcher
            transform.position = resetPosition;
            
            //allowing more launches to happen
            pressTime = 0f;
            
            //sets is so launcher is back up
            launcherAnimator.SetBool("Charging", false);
            //gate goes back up
            gateAnimator.SetBool("Gate", false);
            resetting = false;
    }
}

