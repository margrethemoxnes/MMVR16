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

    public GameObject controller;

    void Awake() {
        source = GetComponent<AudioSource>();
        audioPlayed = false;
       
    }
 
    void OnTriggerStay(Collider col) {
        if (col.gameObject == nitrogen) {
            if (NitrogenScript.nitrogenOpen == true)
            {
                Instantiate(NitrogenGasInWater, new Vector3(303.68f, 10.03f, controller.transform.position.z), Quaternion.identity);
                //if (OnSmallSmoke != null)
                //    OnSmallSmoke();
                //EventManager.TriggerEvent("OnSmallSmoke");
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject == nitrogen) {
                if (NitrogenScript.nitrogenOpen == true)
                {
                    OnSmallSmoke();
                    if (audioPlayed == false)
                    {
                        source.PlayOneShot(applause, 1F);
                        audioPlayed = true;
                    }
            }
        }
    }

    void OnSmallSmoke()
    {
        CasesScripts.ExperimentThree = true;
        DisplayHintsScript.hintDisplayed = false;
        DisplayHintsScript.startTime = Time.time;

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
