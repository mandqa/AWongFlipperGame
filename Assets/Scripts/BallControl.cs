using UnityEngine;
using UnityEngine.InputSystem;

public class BallControl : MonoBehaviour
{
    InputAction launchButton;

    Rigidbody2D myBody; 
    public InputActionAsset inputActions;
    public Animator launcherAnimator;
    public Animator gateAnimator;
    public LivesManager livesManager;
    
    public SoundManager soundManager;

    //pos/area ball allowed to launch from
    public Transform launchArea;
    public bool isExtraBall = false;
    float pressTime = 0f;

    bool hasLaunched = false;
    bool ballInLaunchZone = false;

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
        //saves the start pos of the ball
        resetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //when ball hasnt been launched u can launch
        if (ballInLaunchZone && !hasLaunched && !resetting)
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
        //how strong launch is
        float launchPower = launchForce * pressTime;
        //push ball up
        myBody.AddForce(Vector2.up * launchPower);
        hasLaunched = true;
        soundManager.PlayLaunch();
        //reset charge power
        pressTime = 0f;
        //gate go down
        gateAnimator.SetBool("Gate", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DangerBall") && !resetting)
        {
            resetting = true;

            livesManager.LoseLife();

            if (isExtraBall)
            {
                Invoke("DisableExtraBall", resetDelay);
            }
            else
            {
                Invoke("DangerBall", resetDelay);
            }
        }
        //when ball enters launch zone
        if (other.CompareTag("LaunchZone"))
        {
            ballInLaunchZone = true;
            hasLaunched = false;
            pressTime = 0f;
            gateAnimator.SetBool("Gate", false);
        }
        
        if (other.CompareTag("Reset") && !resetting)
        {
            resetting = true;
            //removes 1 life
            livesManager.LoseLife();
            //hasLaunched = false;
            
            //to make sure extra ball doesnt go into reset position launch zone
            if(isExtraBall)
            {
                Invoke("DisableExtraBall", resetDelay);
            }
            else
            {

                Invoke("ResetBall", resetDelay);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LaunchZone"))
        {
            ballInLaunchZone = false;
            //allow another launch when ball return
            hasLaunched =true;
            pressTime = 0f;
            //stop charge anim
            launcherAnimator.SetBool("Charging", false);
            //raise gate again
            gateAnimator.SetBool("Gate", true);
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
            
            hasLaunched = false;
            
            //sets is so launcher is back up
            launcherAnimator.SetBool("Charging", false);
            //gate goes back up
            gateAnimator.SetBool("Gate", false);
            //allows player to launch again
            resetting = false;
    }

    void DangerBall()
    {
        myBody.linearVelocity = Vector2.zero;
        myBody.angularVelocity = 0f;

        transform.position = resetPosition;

        pressTime = 0f;

        launcherAnimator.SetBool("Charging", false);
        gateAnimator.SetBool("Gate", false);

        resetting = false;
    }

    void DisableExtraBall()
    {
        myBody.linearVelocity = Vector2.zero;
        myBody.angularVelocity = 0f;
        gameObject.SetActive(false);
        resetting = false;
    }
}

