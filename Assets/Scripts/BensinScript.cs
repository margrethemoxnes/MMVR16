using UnityEngine;
using System.Collections;
using System.Timers;

[RequireComponent(typeof(AudioSource))]
public class BensinScript : MonoBehaviour {

    //public delegate void Exploded();
    //public static event Exploded OnExploded;

    public GameObject campfire;
    public GameObject explosion;
    public AudioClip boomSound;
    

    bool played;

    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
        played = false;
    }

    void OnCollisionEnter(Collision col)
    {
        // Sjekk om bensinkanna er på bålet 
        if (col.gameObject == campfire)
        {
            source.PlayOneShot(boomSound, 1F);
            if (source.isPlaying)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                played = true;
            }
            if(played == true)
            {
                Destroy(this.gameObject);
            }
            //if (OnExploded != null)
            //    OnExploded();
            //EventManager.TriggerEvent("OnExploded");
            OnExploded();
        }
    }

    void OnExploded()
    {
        CasesScripts.ExperimentTwo = true;
        //Spill av fullført eksperiment lyd
        if (CasesScripts.ExperimentThree == true)
        {
            CasesScripts.experiment = 4;
        }
        else
        {
            CasesScripts.experiment = 3;
        }
    }
}
