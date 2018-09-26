using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float jumpForce;
    Rigidbody2D rigidBody;
    public Animator animator;
    public float runningSpeed = 1.5f;
    private Vector3 startingPosition;
    public int collectedCoins = 0;

    void Awake()
    {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        transform.position = startingPosition;
        collectedCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            animator.SetBool("isGrounded", IsGrounded());
        }
    }

    void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }
        else
        {
            rigidBody.Sleep();
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public LayerMask groundLayer;

    bool IsGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        return false;
    }

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);

        //check if highscore save if it is
        if (PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance())
        {
            //save new highscore
            PlayerPrefs.SetFloat("highscore", this.GetDistance());
        }
    }

    public float GetDistance()
    {
        float traveldDistance = Vector2.Distance(new Vector2(startingPosition.x, 0),
                                                 new Vector2(this.transform.position.x, 0));
        return traveldDistance;
    }

    public void CollectCoin()
    {
        collectedCoins++;
    }
}
