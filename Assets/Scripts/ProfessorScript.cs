using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ProfessorScript : MonoBehaviour {
    //public delegate void Saved();
    //public static event Saved OnSaved;
    public AudioClip applause;

    Vector3 profPos;
    Vector3 profRot;

    public GameObject telt;
    private AudioSource source;

    // For TurnOffStatic method
    public GameObject bensin;
    public GameObject nitrogen;
    public GameObject nitrogenLid;
    public GameObject bucket;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        profPos = gameObject.transform.position;
        profRot = gameObject.transform.eulerAngles;
    }

    void OnCollisionStay(Collision col) {
        if(col.gameObject == telt){
            gameObject.transform.position = profPos;
            gameObject.transform.position = profRot;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject == telt) {
            source.PlayOneShot(applause, 1F);

            //if (OnSaved != null)
            //     OnSaved();
            //EventManager.TriggerEvent("OnSaved");
            OnSaved();
        }
    }

    void OnSaved()
    {
        CasesScripts.experiment = 2;
        CasesScripts.ExperimentOne = true;
        DisplayHintsScript.startTime = Time.time;
        TurnOffStatic();
    }

    void TurnOffStatic()
    {
        Rigidbody bensinBody = bensin.AddComponent<Rigidbody>();
        bensinBody.mass = 10;

        Rigidbody bucketBody = bucket.AddComponent<Rigidbody>();
        bucketBody.mass = 5;

        Rigidbody nitrogenBody = nitrogen.AddComponent<Rigidbody>();
        nitrogenBody.mass = 50;

        Rigidbody nitrogenLidBody = nitrogenLid.AddComponent<Rigidbody>();
        nitrogenLidBody.mass = 1;
    }

}
