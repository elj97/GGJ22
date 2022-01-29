using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool isJumping = false;
    public PlayerBase settings;
    Vector3 charScale;
    float charScaleX;

    void Start()
    {
        charScale = transform.localScale;
        charScaleX = charScale.x;
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (gameObject.tag == "Player1")
        {
            float moveH = Input.GetAxis("Horizontal1"); //change inputs?
            Vector2 moveDirection = new Vector2(moveH, 0);
            transform.Translate(moveDirection * settings.speed * Time.deltaTime);
            Vector3 localScale = transform.localScale;

            /*flips character*/
            if (moveH < 0)
                charScale.x = -charScaleX;

            else
                charScale.x = charScaleX;

            transform.localScale = charScale;

            if (Input.GetButtonDown("Jump1") && (isJumping == false))
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, settings.jumpHeight), ForceMode2D.Impulse);
        }

        if (gameObject.tag == "Player2") 
        {
            float moveH = Input.GetAxis("Horizontal2"); //change inputs?
            Vector2 moveDirection = new Vector2(moveH, 0);
            transform.Translate(moveDirection * settings.speed * Time.deltaTime);

            /*flips character */
            if (moveH < 0)
                charScale.x = -charScaleX;

            else
                charScale.x = charScaleX;

            transform.localScale = charScale;

            if (Input.GetButtonDown("Jump2") && (isJumping == false))
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, settings.jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJumping = true;
        }
    }
}
