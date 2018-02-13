using System.Collections;
using System;
using UnityEngine;


public class PlayerExample : MonoBehaviour
{

    public float FrictionModifier
    {
        get { return frictionModifier; }
        set { frictionModifier = value; }
    }

    [SerializeField]
    protected int playerNum;

    //added variables for movement, acceleration for ramped up speed
    int horizMove = 0;
    protected int accelerator = 50;
    protected int MAX_MOVE = 1000;

    float frictionModifier = 5f; //This is for if the floor is ice
    protected float speedModifier = 1000f; //This is to control the model's speed within a reasonable speed

    private Rigidbody2D myRigidBody;

    private Animator myAnimator;

    //double damage (double x);

    [SerializeField]
    protected float movementSpeed;

    private bool attack;

    private bool attack2;

    private bool facingRight;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private float jumpForce;

    void Start()
    {
        facingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        bool keyDown = false;

        if (playerNum == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                keyDown = true;
                if (horizMove < MAX_MOVE) { horizMove += (int)(accelerator * frictionModifier); }
            }

            if (Input.GetKey(KeyCode.A))
            {
                keyDown = true;
                if (horizMove > -MAX_MOVE) { horizMove -= (int)(accelerator * frictionModifier); }
            }
        }
        else if (playerNum == 2)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                keyDown = true;
                if (horizMove < MAX_MOVE) { horizMove += (int)(accelerator * frictionModifier); }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                keyDown = true;
                if (horizMove > -MAX_MOVE) { horizMove -= (int)(accelerator * frictionModifier); }
            }
        }

        if (!keyDown)
        {
            if (horizMove != 0)
            {
                if (horizMove < 0) { horizMove += (int)(accelerator * frictionModifier); }
                else { horizMove -= (int)(accelerator * frictionModifier); }
            }
        }


        HandleMovement(horizMove / speedModifier);

        HandleAttacks();

        ResetValues();
    }
    private void HandleMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));
        }

        if (playerNum == 1)
        {
            if (!isGrounded)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    myRigidBody.AddForce(new Vector2(0, -jumpForce / 5));
                }
            }
        }
        else if (playerNum == 2)
        {
            if (!isGrounded)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    myRigidBody.AddForce(new Vector2(0, -jumpForce / 5));
                }
            }
        }

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleAttacks()
    {
        if (attack)
        {
            myAnimator.SetTrigger("attack");
        }
        else if (attack2)
        {
            myAnimator.SetTrigger("attack2");
        }
    }

    private void HandleInput()
    {
        if (playerNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                attack = true;
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                attack2 = true;
            }
        }
        else if (playerNum == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump = true;
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                attack = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightControl))
            {
                attack2 = true;
            }
        }
    }

    private void ResetValues()
    {
        attack = false;

        attack2 = false;

        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
            frictionModifier = 5f;
        }
        else if (col.gameObject.tag == "ice")
        {
            frictionModifier = .5f;
            isGrounded = true;
        }
    }
}
