using UnityEngine;
using System.Collections;

public class flyingPeanutStraight : Enemy
{
    public int travelDistance = 100;
    //private Vector2 travelVector;
    private Vector2 travelStart;
    public bool right;
    private int stepCounter = 0;

    // Use this for initialization
    protected override void Start()
    {
        travelStart = transform.position;
        //travelVector.x = travelVector.x * travelDistance;
        //right = true;
        maxSpeed = 2.0f;
    }

    override protected void Movement()
    {

        if (right)
        {
            transform.position += transform.right * maxSpeed * Time.deltaTime;
            stepCounter++;
        }
        else
        {
            transform.position += transform.right * maxSpeed * Time.deltaTime * -1;
            stepCounter--;
        }

        if (stepCounter == travelDistance)
        {
            right = false;
        }

        if(transform.position.x < travelStart.x)
        {
            right = true;
        }
    }

    override protected void Animate()
    {
        if (right)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (!right)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

}

