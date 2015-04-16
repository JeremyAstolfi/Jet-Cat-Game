using UnityEngine;
using System.Collections;

public class flyingPeanut : Enemy
{
    public float safeDistance = 10;
    private float x;
    private float y;

    public float t;

    public float xOff = 30;
    public float yOff = 20;

    public float xBoundLeft;
    public float xBoundRight;
    public float yBound;

    public bool right;

    
    protected override void Start()
    {
        maxSpeed = 0.2f;

        x = transform.position.x;
        y = transform.position.y;

        right = false;


        xBoundLeft = transform.position.x + -(xOff) * Mathf.Sin(3.1f);
        xBoundRight = transform.position.x + -(yOff) * Mathf.Sin(0.1f);
        yBound = transform.position.y;

    }

    override protected void Movement()
    {
            t += Time.deltaTime;

            if (!right)
            {
                x = -(xOff) * Mathf.Sin(t);
                y = -(yOff) * Mathf.Cos(t);
            }
            else
            {
                x = xOff * Mathf.Sin(-t);
                y = yOff * Mathf.Cos(-t);

            }
            if (transform.position.y > yBound)
            {
                if (transform.position.x < xBoundLeft)
                {
                    right = true;
                }
                if (transform.position.x > xBoundRight)
                {
                    right = false;
                }
            }

            Vector3 mover = new Vector3(x, y, 0);


            transform.position += mover * maxSpeed * Time.deltaTime;
        
        
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
