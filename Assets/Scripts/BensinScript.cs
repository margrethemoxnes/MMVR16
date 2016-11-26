﻿using UnityEngine;
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

    public static AudioSource source;

    bool scriptOff;
    ControllerActionsScript script;
    DisplayHintsScript hints;


    void Awake() {
        source = GetComponent<AudioSource>();
       
        played = false;

        // Sjekk om lyd spilles. Dersom lyd spilles, deaktiver ControllerActionScript. Hindre bruker i å plukke opp noe.
        if (!source.isPlaying)
        {
            script.enabled = false;
            hints.enabled = false;
            scriptOff = true;
        }
        else
        {
            if (scriptOff)
            {
                script.enabled = true;
                hints.enabled = true;
                scriptOff = false;
            }
        }
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
                DisplayExperiments.experimentsDone = 9;
            }
            else
            {
                CasesScripts.experiment = 4;
                DisplayExperiments.experimentsDone = 5;
            }
        }

        else if (CasesScripts.ExperimentFour == true)
        {
            DisplayExperiments.experimentsDone = 6;
            if (CasesScripts.ExperimentFive == true)
            {
                DisplayExperiments.experimentsDone = 11;
            }
            else if (CasesScripts.ExperimentThree == true) {
                DisplayExperiments.experimentsDone = 12;
            }
            else
            {
                DisplayExperiments.experimentsDone = 6;
            }
        }

        else
        {
            CasesScripts.experiment = 3;
            DisplayExperiments.experimentsDone = 1;
        }
    }
    
}
