using UnityEngine;
using System.Collections;
using System.Timers;

[RequireComponent(typeof(AudioSource))]
public class BensinScript : MonoBehaviour {

    //public delegate void Exploded();
    //public static event Exploded OnExploded;

    public GameObject bensin;
    public GameObject explosion;
    public GameObject explosion2;
    public AudioClip boomSound;
    

    bool played;

    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
        played = false;
    }

    void OnTriggerEnter(Collider col)
    {
        // Sjekk om bensinkanna er på bålet 
        if (col.gameObject == bensin)
        {
            source.PlayOneShot(boomSound, 1F);
            if (source.isPlaying)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Instantiate(explosion2, transform.position, Quaternion.identity);
                OnExploded();
                played = true;
            }
            if(played == true)
            {
                Destroy(bensin.gameObject);
            }
            //if (OnExploded != null)
            //    OnExploded();
            //EventManager.TriggerEvent("OnExploded");
            
        }
    }

    void OnExploded()
    {
        CasesScripts.ExperimentTwo = true;

        DisplayHintsScript.hintDisplayed = false;
        DisplayHintsScript.startTime = Time.time;

        if (CasesScripts.ExperimentThree == true)
        {
            if (CasesScripts.ExperimentFour == true)
            {
                CasesScripts.experiment = 5;
                //Oppdater eksperimentliste-materiale i boka
            }
            else
            {
                CasesScripts.experiment = 4;
                //Oppdater eksperimentliste-materiale i boka
            }
        }
        else
        {
            CasesScripts.experiment = 3;
            //Oppdater eksperimentliste-materiale i boka
        }
    }
    
}
