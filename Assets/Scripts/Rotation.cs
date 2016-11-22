using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    int y;

    // Use this for initialization
    void Awake () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        y++;
        gameObject.transform.Rotate(Vector3.up, .5f);
	}
}
