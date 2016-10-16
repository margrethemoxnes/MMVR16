using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LakeScript : MonoBehaviour {

    //public delegate void SmallSmoke();
    //public static event SmallSmoke OnSmallSmoke;
    public GameObject nitrogen;

    public AudioClip applause;
    bool audioPlayed;

    public GameObject NitrogenGasInWater;

    private AudioSource source;

    public TextMesh eureka;

    void Awake() {
        source = GetComponent<AudioSource>();
        audioPlayed = false;
       
    }
 
    void OnCollisionStay(Collision col) {
        if (col.gameObject == nitrogen) {
            if (NitrogenScript.nitrogenOpen == true)
            {
                //eureka.text = "Kollisjon. Og lokket er av.";
                Instantiate(NitrogenGasInWater, transform.position, Quaternion.identity);
                //if (OnSmallSmoke != null)
                //    OnSmallSmoke();
                //EventManager.TriggerEvent("OnSmallSmoke");
            }

        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject == nitrogen) {
            if(audioPlayed == false) { 
                if (NitrogenScript.nitrogenOpen == true)
                {
                    source.PlayOneShot(applause, 1F);
                    audioPlayed = true;
                    OnSmallSmoke();
                }
                else {
                    eureka.text = "Kollisjon. Men lokket er på.";
                }
            }
        }
    }

    void OnSmallSmoke()
    {
        CasesScripts.ExperimentThree = true;
        DisplayHintsScript.hintDisplayed = false;
        DisplayHintsScript.startTime = Time.time;
        //Spill av fullført eksperiment lyd

        if (CasesScripts.ExperimentTwo != true)
        {
            CasesScripts.experiment = 2;
            Debug.Log("Experiment " + CasesScripts.experiment);
        }
        else {
            CasesScripts.experiment = 4;
            Debug.Log("Experiment " + CasesScripts.experiment);
        }

        Debug.Log("Experiment " + CasesScripts.experiment);
    }
}
