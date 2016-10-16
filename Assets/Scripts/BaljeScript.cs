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

    public AudioClip poof;
    private AudioSource source;

    public TextMesh eureka;

    void Awake() {
        nitrogenInBox = false;
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == nitrogen) {
            //Spill av lyd fra professoren. Indikerer at de er på riktig vei.
            eureka.text = "Nitrogen i balja";
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
                    eureka.text = "Ha i nitrogen først";
                    //Lyd. Hmmm....du har kanskje glemt noe....
                }
            }
            else {
                //Lyd. Hmmmm.... kanskje vannet bør ha en annen temperatur?
                eureka.text = "Vannet må kokes";
            }
        }
    }

    void OnPoofed()
    {
        //throw new System.NotImplementedException();
        eureka.text = "Takk for at du spilte";
        CasesScripts.ExperimentFour = true;
        if (CasesScripts.ExperimentTwo == false)
        {
            CasesScripts.experiment = 2;
        }
        else if (CasesScripts.ExperimentThree == false)
        {
            CasesScripts.experiment = 3;
        }
        else
        {
            //Spill av fullført demo lyd
        }
        DisplayHintsScript.hintDisplayed = false;
    }

}
