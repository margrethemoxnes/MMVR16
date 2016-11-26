using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BaljeScript : MonoBehaviour {
    //public delegate void Poofed();
    //public static event Poofed OnPoofed;

    public GameObject nitrogen;
    public static bool nitrogenInBox;
    bool nFirst;
    bool kokFirst;
    public GameObject nitrogenSmokeInBox;
    public GameObject hugeNitrogenSmokeInBox;
    public GameObject bucket;
    public GameObject liquidNitrogen;
    private Renderer nitrogenRend;

    //public AudioClip poof;
    public static AudioSource source;
    public AudioClip nitrogenInContainer;
    public AudioClip haNitrogenFirst;
    public AudioClip vannetKokesForst;
    public AudioClip eureka;

    void Awake() {
        nitrogenInBox = false;
        source = GetComponent<AudioSource>();
        nitrogenRend = liquidNitrogen.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == nitrogen) {
            if(nitrogenInBox == false) { 
                source.PlayOneShot(nitrogenInContainer, 1F);
                nitrogenInBox = true;
                nitrogenRend.enabled = true;
            }
            Instantiate(nitrogenSmokeInBox, transform.position, Quaternion.identity);
        }

        if (col.gameObject == bucket) {
            
            if (BucketScript.boiled == true)
            {
                if (nitrogenInBox == true)
                {
                    //Spill av POOF
                    //eureka.text = "POOF";
                    Instantiate(hugeNitrogenSmokeInBox, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                    //if (OnPoofed != null)
                    //    OnPoofed();
                    //EventManager.TriggerEvent("OnPoofed");
                    OnPoofed();
                }
                else {
                    if(nFirst == false) { 
                        source.PlayOneShot(haNitrogenFirst, 1F);
                        nFirst = true;
                    }
                }
            }
            else {
                if(kokFirst == false) { 
                    source.PlayOneShot(vannetKokesForst, 1F);
                    kokFirst = true;
                }
            }
        }
    }

    void OnPoofed()
    {
        //throw new System.NotImplementedException();
        if(CasesScripts.ExperimentFive == false) { 
            CasesScripts.ExperimentFive = true;
            source.PlayOneShot(eureka, 1F);
        }

        DisplayHintsScript.hintDisplayed = false;
        DisplayHintsScript.startTime = Time.time;

        //Sjekk om alle eksperimenter er utført.

        if (CasesScripts.ExperimentTwo == true)
        {
            if (CasesScripts.ExperimentThree == true)
            {
                //Alle eksperimentene er ferdig
                CasesScripts.experiment = 6;
                //Oppdater eksperimentliste-materiale i boka
                DisplayExperiments.experimentsDone = 12;
            }
            else
            {
                CasesScripts.experiment = 3;
                //Oppdater eksperimentliste-materiale i boka
                DisplayExperiments.experimentsDone = 11;
            }
        }
        else if (CasesScripts.ExperimentThree == true) {
            DisplayExperiments.experimentsDone = 10;
        }
        else
        {
            CasesScripts.experiment = 2;
            //Oppdater eksperimentliste-materiale i boka
            DisplayExperiments.experimentsDone = 8;
        }

    }
}
