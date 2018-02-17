using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int Damage
    {
        get { return damage; }
    }

    public int PlayerNum
    {
        get { return playerNum; }
        set { playerNum = value; }
    }

    public bool FacingRight
    {
        get { return facingRight; }
        set { facingRight = value; }
    }

    [SerializeField]
    float speed;
    float horizMove;

    [SerializeField]
    int playerNum;

    [SerializeField]
    int damage;

    Rigidbody2D rBody;

    private bool hasGravity;
    protected bool isShooting;
    protected bool facingRight;
    protected bool pickedUp;

	// Use this for initialization
	void Start () {
        hasGravity = true;
        isShooting = false;
        facingRight = false;
        pickedUp = false;
        playerNum = 0;
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(!hasGravity)
        {
            rBody.gravityScale = 0;
        }

        if(isShooting)
        {
            if(facingRight)
            {
                horizMove = 2.5f;
            }
            else
            {
                horizMove = -2.5f;
            }
        }

        HandleMovement(horizMove);
    }

    public void HandleMovement(float horizontal)
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    public void Shoot (Transform t)
    {
        isShooting = true;
        // need to adjust position based on players direction
        transform.position = t.position;
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "player")
        {
            if (!pickedUp && (this.playerNum == 0 || this.playerNum == col.gameObject.GetComponent<Player>().PlayerNum))
            {
                transform.localScale = new Vector3(0, 0, 0);
                transform.position = new Vector3(1000, 30000, 0);
                pickedUp = true;
                hasGravity = false;
            }
            else if(isShooting && this.playerNum != col.gameObject.GetComponent<Player>().PlayerNum)
            {
                isShooting = false;
                Destroy(this.gameObject);
            }
        }
        
    }
}
