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
 

    void OnTriggerEnter(Collider col) {
        if (col.gameObject == nitrogen) {
                if (NitrogenScript.nitrogenOpen == true)
                {
                    Instantiate(NitrogenGasInWater, new Vector3(303.68f, 10.03f, controller.transform.position.z), Quaternion.identity);
                    if (audioPlayed == false)
                    {
                        source.PlayOneShot(applause, 1F);
                        audioPlayed = true;
                        OnSmallSmoke();
                }
            }
        }
    }

    void OnSmallSmoke()
    {

        CasesScripts.ExperimentThree = true;
        DisplayHintsScript.hintDisplayed = false;
        DisplayHintsScript.startTime = Time.time;

        if (CasesScripts.ExperimentTwo == true)
        {
            if (CasesScripts.ExperimentFour == true)
            {
                if (CasesScripts.ExperimentFive == true)
                {
                    DisplayExperiments.experimentsDone = 12;
                }
                else
                {
                    DisplayExperiments.experimentsDone = 7;
                }

                CasesScripts.experiment = 5;
                DisplayExperiments.experimentsDone = 9;

            }
            else
            {
                CasesScripts.experiment = 4;
                DisplayExperiments.experimentsDone = 5;
            }
        }
        else if (CasesScripts.ExperimentFour == true) {
            DisplayExperiments.experimentsDone = 7;
            if (CasesScripts.ExperimentFive == true) {
                DisplayExperiments.experimentsDone = 10;
            }
        }
        else
        {
            CasesScripts.experiment = 2;
            DisplayExperiments.experimentsDone = 2;
        }
    }
}