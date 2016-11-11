using UnityEngine;
using System.Collections;

public class DisplayHintsScript : MonoBehaviour {

    public static bool hintDisplayed;
    public Material experiment2;
    public Material experiment3;
    public Material experiment4;
    public static float startTime;
    public static float elapsedTime;
    public static float hintTime;
    public AudioClip hintAvailable;
    private AudioSource source;
    private Renderer rend;
    
    void Awake () {
        hintDisplayed = true;
        hintTime = 60;
        source = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }
	
	void FixedUpdate () {
        if(CasesScripts.ExperimentFour == false && CasesScripts.ExperimentOne == true) { 
            DisplayHints();
        }
    }

    void DisplayHints() {
        elapsedTime = Time.time - startTime;
        if (elapsedTime > hintTime)
        {
            if (hintDisplayed == false)
            {
                hintDisplayed = true;
                
               
                //Aktiver materialet utifra aktivt experiment
                switch (CasesScripts.experiment)
                {
                    case 2:
                        if (ControllerActionsScript.bensinPlayed == true) {
                            source.PlayOneShot(hintAvailable, 1F);
                            rend.material = experiment2;
                        }
                        break;
                    case 3:
                        if(BucketScript.vannPlayed == true) {
                            source.PlayOneShot(hintAvailable, 1F);
                            rend.material = experiment3;
                        }
                        break;
                    case 4:
                        if (ControllerActionsScript.nitrogenPlayed == true)
                        {
                            source.PlayOneShot(hintAvailable, 1F);
                            rend.material = experiment4;
                        }
                        break;
                }
            }
        }
    }
}
