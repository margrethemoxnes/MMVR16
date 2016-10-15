using UnityEngine;
using System.Collections;

public class CountErrorsScript : MonoBehaviour {

    public static int error;
    public AudioClip displayHint;
    public static TextMesh errorsCount;

    private AudioSource source;
    // Use this for initialization
    void Awake () {
        error = 0;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (error == 2 && CasesScripts.experiment != 1) {
            source.PlayOneShot(displayHint, 1F);
        }
	}
}
