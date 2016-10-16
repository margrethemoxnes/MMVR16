using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ProfessorScript : MonoBehaviour {
    //public delegate void Saved();
    //public static event Saved OnSaved;
    public AudioClip applause;
    public TextMesh eureka;

    public GameObject telt;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject == telt) {
            source.PlayOneShot(applause, 1F);

            //if (OnSaved != null)
            //     OnSaved();
            //EventManager.TriggerEvent("OnSaved");
            OnSaved();
        }
    }

    void OnSaved()
    {
        CasesScripts.experiment = 2;
        CasesScripts.ExperimentOne = true;
        Debug.Log("Experiment " + CasesScripts.experiment);
    }

}
