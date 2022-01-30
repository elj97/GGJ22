using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    bool isJumping = false;
    public PlayerBase settings;
    Vector3 charScale;
    float charScaleX;

    Animator animator;


    private MagnetHandler Magnet;

    #region  
    //public AudioClip Jump;
    //public AudioClip[] SwitchMagnet;
    //public AudioClip[] MagnetInteraction;

    
    #endregion


    void Start()
    {
        

        animator = GetComponent<Animator>();


        Magnet = GetComponent<MagnetHandler>();


        charScale = transform.localScale;
        charScaleX = charScale.x;
    }
    void Update()
    {
        //Move();

        if( gameObject.tag == "Player1" )
		{
            Move("Horizontal1");
            Jump("Jump1");
            ChangeDirection("Vertical1");
        }

        if ( gameObject.tag == "Player2" )
        {
            Move("Horizontal2");
            Jump("Jump2");
            ChangeDirection("Vertical2");
        }
    }

    void Move(string keyPress)
    {
        float moveH = Input.GetAxis(keyPress);
        Vector2 moveDirection = new Vector2(moveH, 0);
        transform.Translate(moveDirection * settings.speed * Time.deltaTime);
        Vector3 localScale = transform.localScale;

        // flips character
        if ( moveH < 0 )
        {
            charScale.x = -charScaleX;
            AnimWalk();
        }
        else if ( moveH > 0 )
        {
            charScale.x = charScaleX;
            AnimWalk();
        }
        else
        {
            AnimIdle();
        }

        transform.localScale = charScale;
    }

    void Jump(string keyPress)
    {
        if ( Input.GetButtonDown(keyPress) && (isJumping == false) )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, settings.jumpHeight), ForceMode2D.Impulse);
            AnimJump();
        }
        else
        {
            AnimJumpFinish();
        }
    }

    void ChangeDirection(string keyPress)
    {
        float lookV = Input.GetAxis(keyPress);
        Vector2 lookDirection = new Vector2(lookV, 0);

        if ( lookV < 0 )
        {
            AnimDirection(Direction.Down);
            // Code for changing the magnet direction
            //Debug.Log("change dir down");
        }
        if ( lookV > 0 )
        {
            AnimDirection(Direction.Up);
            // Code for changing the magnet direction
            //Debug.Log("change dir up");
        }
        else
        {
            AnimDirection(Direction.Straight);
            // Code for changing the magnet direction
            //Debug.Log("change dir straight");
        }
    }
    /*
    void Move()
    {
        if ( gameObject.tag == "Player1" )
        {
            float moveH = Input.GetAxis("Horizontal1"); //change inputs?
            Vector2 moveDirection = new Vector2(moveH, 0);
            transform.Translate(moveDirection * settings.speed * Time.deltaTime);
            Vector3 localScale = transform.localScale;

            //flips character//
            if ( moveH < 0 )
			{
                charScale.x = -charScaleX;
                AnimWalk();
            }    
            else if ( moveH > 0 )
			{
                charScale.x = charScaleX;
                AnimWalk();
            }
			else
			{
                AnimIdle();
			}

            transform.localScale = charScale;

            if ( Input.GetButtonDown("Jump1") && (isJumping == false) )
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, settings.jumpHeight), ForceMode2D.Impulse);
                AnimJump();
            }
            else
            {
                AnimJumpFinish();
            }

        }

        if ( gameObject.tag == "Player2" )
        {
            float moveH = Input.GetAxis("Horizontal2"); //change inputs?
            Vector2 moveDirection = new Vector2(moveH, 0);
            transform.Translate(moveDirection * settings.speed * Time.deltaTime);

            //flips character //
            if ( moveH < 0 )
			{
                charScale.x = -charScaleX;
                AnimWalk();
            }   
            else if ( moveH > 0 )
			{
                charScale.x = charScaleX;
                AnimWalk();
            }
            else
            {
                AnimIdle();
            }

            transform.localScale = charScale;

            if ( Input.GetButtonDown("Jump2") && (isJumping == false) )
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, settings.jumpHeight), ForceMode2D.Impulse);
                AnimJump();
            }
			else
			{
                AnimJumpFinish();
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.tag == "Ground" )
        {
            isJumping = false;
            //AnimJumpFinish();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ( collision.collider.tag == "Ground" )
        {
           isJumping = true;
           //AnimJump();
       }
   }

    #region Animation
    private void AnimWalk()
    {
        if ( Magnet.PlayerMagnetState == MagnetHandler.MagnetState.Positive )
        {
            animator.SetBool("PosWalk", true);
            animator.SetBool("PosIdle", false);
        }
        if ( Magnet.PlayerMagnetState == MagnetHandler.MagnetState.Negative )
        {
            animator.SetBool("NegWalk", true);
            animator.SetBool("NegIdle", false);
        }
    }

    private void AnimIdle()
    {
        if ( Magnet.PlayerMagnetState == MagnetHandler.MagnetState.Positive )
        {
            animator.SetBool("PosWalk", false);
            animator.SetBool("PosIdle", true);
        }
        if ( Magnet.PlayerMagnetState == MagnetHandler.MagnetState.Negative )
        {
            animator.SetBool("NegWalk", false);
            animator.SetBool("NegIdle", true);
        }
    }

    private void AnimMagnetState(bool positive) 
    {
        animator.SetBool("Positive", positive);
    }

    private void AnimJump()
	{
        animator.SetBool("Jumping", true);
	}

    private void AnimJumpFinish()
    {
        animator.SetBool("Jumping", false);
    }

    //new code
    private void AnimDirection(Direction dir)
    {
        animator.SetBool("Up", false);
        animator.SetBool("Straight", false);
        animator.SetBool("Down", false);
        
        switch ( dir )
        {
            case Direction.Straight:
                animator.SetBool("Straight", true);
                Debug.Log("change dir straight");
                break;
            case Direction.Up:
                animator.SetBool("Up", true);
                Debug.Log("change dir up");
                break;
            case Direction.Down:
                animator.SetBool("Down", true);
                Debug.Log("change dir down");
                break;
        }
    }
    enum Direction
    {
        Straight,
        Up,
        Down,
    }
    // AnimJump, AnimIdleUp, AnimIdleDown, 
    #endregion
}
