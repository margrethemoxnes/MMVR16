using UnityEngine;
using System.Collections;

public class DisplayHintsScript : MonoBehaviour {

    public static bool hintDisplayed;
    public Material experiment2;
    public Material experiment3;
    public Material experiment4;
    float startTime;
    float elapsedTime;
    float hintTime;
    public AudioClip hintAvailable;
    private AudioSource source;
    private Renderer rend;

    // Use this for initialization
    void Awake () {
        hintDisplayed = false;
        startTime = Time.time;
        hintTime = 120;
        source = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        elapsedTime = Time.time - startTime;
        //Sjekk etter inaktivitet
        DisplayHints(CasesScripts.experiment);
	}

    void DisplayHints(int hint) {
        if (hintDisplayed == false)
        {
            if (elapsedTime > hintTime)
            {
                hintDisplayed = true;
                //Aktiver materialet utifra aktivt experiment
                switch (hint)
                {
                    case 2:
                        rend.material = experiment2;
                        elapsedTime += hintTime;
                        source.PlayOneShot(hintAvailable, 1F);
                        break;
                    case 3:
                        rend.material = experiment3;
                        elapsedTime += hintTime;
                        source.PlayOneShot(hintAvailable, 1F);
                        break;
                    case 4:
                        rend.material = experiment4;
                        elapsedTime += hintTime;
                        source.PlayOneShot(hintAvailable, 1F);
                        break;
                }
            }

        }
    }
}
