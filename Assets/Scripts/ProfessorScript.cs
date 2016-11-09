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
            if(audioPlaying == false) {
                audioPlaying = true;
                source.PlayOneShot(tutorial, 1F);
                OnSaved();
            }
        }
    }

    void FixedUpdate()
    {
        // Sjekk når professoren er ferdig å prate
        if (!source.isPlaying && audioPlaying == true)
        {            
            tutorialPlayed = true;
        }
    }

    void OnSaved()
    {
        CasesScripts.experiment = 2;
        if(tutorialPlayed == true) {
            CasesScripts.ExperimentOne = true;
        }
        TurnOffStatic();
    }

    void TurnOffStatic()
    {
        Rigidbody bensinBody = bensin.AddComponent<Rigidbody>();

        Rigidbody bucketBody = bucket.AddComponent<Rigidbody>();

        Rigidbody nitrogenBody = nitrogen.AddComponent<Rigidbody>();

        Rigidbody nitrogenLidBody = nitrogenLid.AddComponent<Rigidbody>();

        Rigidbody grillBody = grill.AddComponent<Rigidbody>();
    }

}
