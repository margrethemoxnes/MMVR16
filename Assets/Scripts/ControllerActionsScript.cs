using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerActionsScript : MonoBehaviour {

    public GameObject professor;
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);        
	}

    //Plukk opp
    void OnTriggerStay(Collider col)
    {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (col.gameObject == professor)
            {
                if (CasesScripts.experiment != 1)
                {
                    // Lyd. Jeg må slappe av litt.
                }
                else {
                    //Kode for å dra
                    col.attachedRigidbody.isKinematic = true;
                    col.gameObject.transform.SetParent(gameObject.transform);
                }
            }
            else { 
                col.attachedRigidbody.isKinematic = true;
                col.gameObject.transform.SetParent(gameObject.transform);
            }
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (col.gameObject == professor)
            {
                Rigidbody profBody = col.gameObject.GetComponent<Rigidbody>();

                if (CasesScripts.ExperimentOne == true)
                {
                    if (professor.transform.position.y == 0) { 
                        Destroy(profBody);
                    }
                }
            }
            col.attachedRigidbody.isKinematic = false;
            col.gameObject.transform.SetParent(null);

            tossObject(col.attachedRigidbody);
        }

       
    }

    void tossObject(Rigidbody rigidBody) {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity);
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else {
            rigidBody.velocity = device.velocity;
            rigidBody.angularVelocity = device.angularVelocity;
        }
    }

}
