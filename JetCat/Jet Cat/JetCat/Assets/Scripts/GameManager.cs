using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float gravity;
    private float score;
    public JetCatInteraction character;
    private GameObject[] enemiesG;
    private GameObject[] enemiesF;
    private GameObject[] platforms;

	void Start () {
        Initialize();
        score = 0;
        enemiesG = GameObject.FindGameObjectsWithTag("Ground Enemies");
        enemiesF = GameObject.FindGameObjectsWithTag("Flying Enemies");
        platforms = GameObject.FindGameObjectsWithTag("Platform");
	}
	

	void Update () 
    {
        if (character.health <= 0 || character.transform.position.y < -7)
        {
            Application.LoadLevel(0);
        }
	}

    private void Initialize()
    {
        if (gravity == 0)
        {
            gravity = 4f;
        }
    }

    public float Score
    {
        get { return score;  }
        set { score = value; }
    }

}
