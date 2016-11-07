using UnityEngine;
using System.Collections;

public class RotationNitrogen : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.Rotate(Vector3.right, 1f);
    }
}
