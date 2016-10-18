using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BaljeScript : MonoBehaviour {
    //public delegate void Poofed();
    //public static event Poofed OnPoofed;

    public GameObject nitrogen;
    public static bool nitrogenInBox;
    public GameObject nitrogenSmokeInBox;
    public GameObject hugeNitrogenSmokeInBox;
    public GameObject bucket;

    //public AudioClip poof;
    //private AudioSource source;

    void Awake() {
        nitrogenInBox = false;
        //source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == nitrogen) {
            //Spill av lyd fra professoren. Indikerer at de er på riktig vei.
            //eureka.text = "Nitrogen i balja";
                nitrogenInBox = true;
                Instantiate(nitrogenSmokeInBox, transform.position, Quaternion.identity);
        }

        if (col.gameObject == bucket) {
            
            if (BucketScript.boiled == true)
            {
                if (nitrogenInBox == true)
                {
                    //Spill av POOF
                    //eureka.text = "POOF";
                    Instantiate(hugeNitrogenSmokeInBox, transform.position, Quaternion.identity);
                    //if (OnPoofed != null)
                    //    OnPoofed();
                    //EventManager.TriggerEvent("OnPoofed");
                    OnPoofed();
                }
                else {
                    //eureka.text = "Ha i nitrogen først";
                    //Lyd. Hmmm....du har kanskje glemt noe....
                }
            }
            else {
                //Lyd. Hmmmm.... kanskje vannet bør ha en annen temperatur?
                //eureka.text = "Vannet må kokes";
            }
        }
    }

    void OnPoofed()
    {
        //throw new System.NotImplementedException();
        CasesScripts.ExperimentFour = true;

        //Sjekk om alle eksperimenter er utført.
        if (CasesScripts.ExperimentThree != true)
        {
            CasesScripts.experiment = 3;
            //eureka.text = CasesScripts.experiment.ToString();
            Debug.Log("Experiment " + CasesScripts.experiment);
            DisplayHintsScript.hintDisplayed = false;
            DisplayHintsScript.startTime = Time.time;
        }
        else if (CasesScripts.ExperimentTwo != true)
        {
            CasesScripts.experiment = 2;
            Debug.Log("Experiment " + CasesScripts.experiment);
            DisplayHintsScript.hintDisplayed = false;
            DisplayHintsScript.startTime = Time.time;
        }
        else
        {
         //   eureka.text = "Finished!";
        }
    }

}
