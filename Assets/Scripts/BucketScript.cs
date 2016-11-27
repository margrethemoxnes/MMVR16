using UnityEngine;
using System.Collections;

public class BucketScript : MonoBehaviour {

    public static bool waterInBucket;
    public GameObject lake;
    public GameObject campfire;
    public TextMesh degrees;
    public static bool boiled;
    private Renderer rend;
    public GameObject bucketWater;

    private AudioSource source;
    public AudioClip vannetErKokt;

    public GameObject h2o;
    private Renderer vannRend;
    public GameObject planeVann;
    public AudioClip vann;
    public static bool vannPlayed;

    public GameObject book;
    Renderer LeftPageRender;
    public Material experiment3;
    public Material experiment1_3;
    public Material experiment2_3;
    public Material experiment1_2_3;

    bool scriptOff;
    ControllerActionsScript script;
    DisplayHintsScript hint;

    void Awake()
    {
        boiled = false;
        waterInBucket = false;
        vannPlayed = false;
        rend = bucketWater.GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        vannRend = planeVann.GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        // Sjekk om lyd spilles. Dersom lyd spilles, deaktiver ControllerActionScript. Hindre bruker i å plukke opp noe.
        //if (!source.isPlaying)
        //{
        //    script.enabled = false;
        //    hint.enabled = false;
        //    scriptOff = true;
        //}
        //else
        //{
        //    if (scriptOff) { 
        //        script.enabled = true;
        //        hint.enabled = true;
        //        scriptOff = false;
        //    }
        //}
    }
   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == lake)
        {
            waterInBucket = true;
            rend.enabled = true;
            degrees.text = "2°C";
            EnableWater();
        }
    //}

    //void OnCollisionEnter(Collision col) { 
        if (col.gameObject == campfire)
        {
            if (boiled == false) { 
                if (waterInBucket == true)
                {
                    degrees.text = "100°C";
                    boiled = true;
                    source.PlayOneShot(vannetErKokt, 1F);
                    onBoiledWater();
                }
            }
        }
    }

    void EnableWater()
    {
        if (BucketScript.waterInBucket == true)
        {
            if (vannPlayed == false)
            {
                source.PlayOneShot(vann, 1F);
                vannPlayed = true;
                h2o.transform.localScale = new Vector3(2f, 2f, 2f);
                vannRend.enabled = true;
                DisplayHintsScript.hintDisplayed = false;
                DisplayHintsScript.startTime = Time.time;
            }
        }
    }

    void onBoiledWater()
    {
        CasesScripts.ExperimentFour = true;
        DisplayHintsScript.hintDisplayed = false;
        DisplayHintsScript.startTime = Time.time;

        if (CasesScripts.ExperimentTwo == true)
        {
            if (CasesScripts.ExperimentThree == true)
            {
                CasesScripts.experiment = 5;
                //Oppdater eksperimentliste-materiale i boka
                DisplayExperiments.experimentsDone = 9;
            }
            else
            {
                CasesScripts.experiment = 3;
                //Oppdater eksperimentliste-materiale i boka
                DisplayExperiments.experimentsDone = 6;
            }
        }
        else if (CasesScripts.ExperimentThree == true) {
            DisplayExperiments.experimentsDone = 7;
        }
        else
        {
            CasesScripts.experiment = 2;
            //Oppdater eksperimentliste-materiale i boka
            DisplayExperiments.experimentsDone = 3;
        }
    }
}
