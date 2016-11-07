using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerActionsScript : MonoBehaviour {

    public GameObject professor;
    public GameObject Nitrogen;
    public GameObject Co;
    public GameObject O2;
    public GameObject H2O;
    public GameObject Bensin;

    Vector3 NitrogenPos;
    Vector3 CoPos;
    Vector3 O2Pos;
    Vector3 H2oPos;
    Vector3 BensinPos;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    private AudioSource source;
    public AudioClip hvile;

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        source = GetComponent<AudioSource>();
        NitrogenPos = Nitrogen.transform.position;
        CoPos = Co.transform.position;
        O2Pos = O2.transform.position;
        H2oPos = H2O.transform.position;
        BensinPos = Bensin.transform.position;
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
                    source.PlayOneShot(hvile, 1F);
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

            Nitrogen.transform.position = NitrogenPos;
            H2O.transform.position = H2oPos;
            Co.transform.position = CoPos;
            Bensin.transform.position = BensinPos;
            O2.transform.position = O2Pos;
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
