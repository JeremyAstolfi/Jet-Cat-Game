using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private GameObject character;

	// Use this for initialization
	void Start () {
        character = GameObject.FindGameObjectWithTag("Character");
	}
	
	// Update is called once per frame
	void LateUpdate () {
       transform.position = new Vector3(character.transform.position.x +5, 0, transform.position.z);
	}
}
