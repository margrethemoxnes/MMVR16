using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ProfessorScript : MonoBehaviour {
    //public delegate void Saved();
    //public static event Saved OnSaved;
    public AudioClip tutorial;

    Vector3 profPos;
    Vector3 profRot;

    public GameObject telt;
    private AudioSource source;

    // For TurnOffStatic method
    public GameObject bensin;
    public GameObject nitrogen;
    public GameObject nitrogenLid;
    public GameObject bucket;
    public GameObject grill;
    bool audioPlaying;
    public static bool tutorialPlayed;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        tutorialPlayed = false;
        audioPlaying = false;
    }


    

    void OnTriggerExit(Collider col) {
        if (col.gameObject == telt) {
            source.PlayOneShot(tutorial, 1F);
            audioPlaying = true;
        }
    }

    void FixedUpdate()
    {
        // Sjekk når professoren er ferdig å prate
        if (!source.isPlaying && audioPlaying == true)
        {
            OnSaved();
            tutorialPlayed = true;
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

        Rigidbody grillBody = grill.AddComponent<Rigidbody>();
        grillBody.mass = 1;
    }

}
