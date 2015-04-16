using UnityEngine;
using System.Collections;

public class JetCatInteraction : MonoBehaviour {

    public enum Action
    {
        Standing,
        Jumping,
        Falling,
        Jetpack
    }
    private enum Movement
    {
        Idle,
        MovingLeft,
        MovingRight
    }

    #region Variables
    public int health;
    public float moveSpeed;
    public float jumpWeight;
    public float fuelAmount;
    public GameManager gM;
    public Action action;
    private Movement move;
    private float upAcceleration;
    public Animation jump;
    public Animation fall;
    #endregion

    void Start () {
        action = Action.Falling;
        move = Movement.Idle;
        Initialize();
	}
	
	void Update () {
        //TouchMovement();
        KeyMovement();
        Jump();
        Move();
        ApplyGravity();
        transform.rotation = new Quaternion(0, 0, 0, 0);
	}

    private void TouchMovement()
    {
        move = Movement.Idle;
        if (Input.GetTouch(0).position.x <= Screen.width / 4 || Input.GetTouch(1).position.x <= Screen.width / 4)
        {
            move = Movement.MovingLeft;
        }
        if (Input.GetTouch(0).position.x >= (Screen.width * 3 / 4) || Input.GetTouch(1).position.x >= (Screen.width * 3 / 4))
        {
            move = Movement.MovingRight;
        }
        if (Input.GetTouch(0).position.x > Screen.width / 4 && Input.GetTouch(0).position.x < (Screen.width * 3 / 4))
        {
            CheckJump();
        }
        if (Input.GetTouch(1).position.x > Screen.width / 4 && Input.GetTouch(1).position.x < (Screen.width * 3 / 4))
        {
            CheckJump();
        }
    }
    private void KeyMovement()
    {
        move = Movement.Idle;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move = Movement.MovingLeft;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move = Movement.MovingRight;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckJump();
        }
    }

    private void CheckJump()
    {
        if (action == Action.Standing)
        {
            action = Action.Jumping;
            upAcceleration = jumpWeight;
        }
        else if (action == Action.Jumping || action == Action.Falling)
        {
            if (fuelAmount == 0)
            {
                //Make poot sound
            }
            else
            {
                action = Action.Jetpack;
                upAcceleration = jumpWeight;
                fuelAmount--;
            }
        }
    }

    private void Move()
    {
        if (move == Movement.MovingLeft)
        {
            transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        if (move == Movement.MovingRight)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }
    private void Jump()
    {
        if (action == Action.Jumping)
        {
            transform.position += transform.up * upAcceleration * Time.deltaTime;
        }
        if (action == Action.Jetpack)
        {
            transform.position += transform.up * upAcceleration * Time.deltaTime;
        }
        if (upAcceleration < 0)
        {
            upAcceleration = 0;
        }
        else
        {
            upAcceleration -= 0.5f;
        }
    }

    private void ApplyGravity()
    {
        if (action == Action.Jumping || action == Action.Falling || action == Action.Jetpack)
        {
            transform.position += -transform.up * gM.gravity * Time.deltaTime;
        }
    }

    private void AnimateSet()
    {
        switch(action)
        {
            case Action.Jumping:
                this.animation.GetComponent("Jump");
                break;
            case Action.Falling:
                this.animation.GetComponent("Jump");
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        #region Platform
        if (col.gameObject.tag == "Platform")
        {
            if (transform.position.y - transform.localScale.y >= col.transform.position.y + col.transform.localScale.y)
            {
                action = Action.Standing;
            }
            else
            {
                action = Action.Falling;
            }
        }
        #endregion
        #region Fishy Crackers
        if (col.gameObject.tag == "Fishy Cracker")
        {
            gM.Score += 100;
            Destroy(col.gameObject);
        }
        #endregion
        #region Heart
        if (col.gameObject.tag == "Heart")
        {
            if (health == 3)
            {
                gM.Score += 1000;
            }
            else
            {
                health++;
            }
            Destroy(col.gameObject);
        }
        #endregion
        #region Enemies
        if (col.gameObject.tag == "Ground Enemies" || col.gameObject.tag == "Flying Enemies")
        {
            if (transform.position.y - transform.localScale.y >= col.transform.position.y + col.transform.localScale.y)
            {
                action = Action.Jumping;
                upAcceleration = jumpWeight;
                Destroy(col.gameObject);
            }
            else
            {
                health--;
            }
        }
        #endregion
    }

    void OnCollisionExit2D(Collision2D col)
    {
        action = Action.Jumping;
        if (col.gameObject.tag == "Platform" && action != Action.Jumping && (transform.position.x < col.transform.position.x - col.transform.localScale.x || transform.position.x > col.transform.position.x + col.transform.localScale.x))
        {
            action = Action.Falling;
        }
    }
    private void Initialize()
    {
        if(health == 0)
        {
            health = 3;
        }
        if (moveSpeed == 0)
        {
            moveSpeed = 8;
        }
        if (jumpWeight == 0)
        {
            jumpWeight = 20;
        }
        if (fuelAmount == 0) {
            fuelAmount = 3; 
        }
    }

}
