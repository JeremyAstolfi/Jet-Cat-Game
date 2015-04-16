using UnityEngine;
using System.Collections;

abstract public class Enemy : MonoBehaviour 
{

    private Vector2 position;
    public float maxSpeed = 0.5f;
    public float maxForce = 10.0f;
    public float mass = 1.0f;
    public float gravity = 20.0f;
    public float width;
    public float height;
    
    protected Vector2 velocity;
    protected Vector2 acceleration;
    protected CharacterController characterController;

    public Vector2 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    virtual protected void Start () 
    {
        acceleration = Vector2.zero;
        characterController = gameObject.GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        Movement(); 
        Animate();        

	}

    abstract protected void Movement(); //will be defined in the specific enamy classes, different enemys will have different movements

    abstract protected void Animate(); // will be defined later becuase this is not a specific enemy
}
