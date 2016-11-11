using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerActionsScript : MonoBehaviour {

    public GameObject professor;
    public GameObject Nitrogen;
    public GameObject Co;
    public GameObject O2;
    public GameObject H2O;
    public GameObject Bensin;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    private AudioSource source;
    public AudioClip hvile;

    // Info - Lyd
    [System.Serializable]
    public class InfoSoundGameObjects{
        public AudioClip vann;
        public AudioClip nitrogen;
        public AudioClip fuel;
        public AudioClip co;
        public AudioClip oksygen;
    }

    // Info - Plan
    [System.Serializable]
    public class InfoGameObjects
    {
        public GameObject bensin;
        public GameObject vann;
        public GameObject karbonmonoksid;
        public GameObject nitrogen;
        public GameObject oksygen;
    }

    // Molecules and atom
    [System.Serializable]
    public class MoleculeGameObjects
    {
        public GameObject b8h18;
        public GameObject co;
        public GameObject n;
        public GameObject o2;
        public GameObject h2o;
    }

    //Objects to trigger info and molecules
    [System.Serializable]
    public class TriggerObjects
    {
        public GameObject bensinkanne;
        public GameObject grill;
        public GameObject nitrogenlokk;
        public GameObject bucket;
    }

    
    // Renderers
    private Renderer bensinRend;
    private Renderer vannRend;
    private Renderer coRend;
    private Renderer nitrogenRend;
    private Renderer oksygenRend;

    // played bools
    public static bool bensinPlayed;
    bool vannPlayed;
    bool coPlayed;
    public static bool nitrogenPlayed;
    bool oksygenPlayed;

    public InfoGameObjects planes;
    public MoleculeGameObjects molecules;
    public TriggerObjects objects;
    public InfoSoundGameObjects sounds;

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        source = GetComponent<AudioSource>();

        bensinRend = planes.bensin.GetComponent<Renderer>();
        vannRend = planes.vann.GetComponent<Renderer>();
        coRend = planes.karbonmonoksid.GetComponent<Renderer>();
        nitrogenRend = planes.nitrogen.GetComponent<Renderer>();
        oksygenRend = planes.oksygen.GetComponent<Renderer>();
        vannPlayed = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    //Plukk opp
    void OnTriggerStay(Collider col)
    {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (col.gameObject == professor)
            {
                if (CasesScripts.experiment != 1)
                {
                    source.PlayOneShot(hvile, 1F);
                }
                else
                {
                    col.attachedRigidbody.isKinematic = true;
                    col.gameObject.transform.SetParent(gameObject.transform);
                }
            }
            else { 
                if(ProfessorScript.tutorialPlayed == true) { 
                    col.attachedRigidbody.isKinematic = true;
                    col.gameObject.transform.SetParent(gameObject.transform);
                }
            }
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {

            col.attachedRigidbody.isKinematic = false;
            col.gameObject.transform.SetParent(null);

            tossObject(col.attachedRigidbody);
        }

       
    }

    void tossObject(Rigidbody rigidBody) {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity);
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else {
            rigidBody.velocity = device.velocity;
            rigidBody.angularVelocity = device.angularVelocity;
        }
    }

    void EnableOxygen() {
        molecules.o2.transform.localScale = new Vector3(2f, 2f, 2f);
        oksygenRend.enabled = true;
    }

    void EnableCarbonmonokside()
    {   
        if (coPlayed == false)
        {
            source.PlayOneShot(sounds.co, 1F);
            coPlayed = true;
            molecules.co.transform.localScale = new Vector3(.5f, .5f, .5f);
            coRend.enabled = true;
        }
    }

    void EnableWater() {
        if(BucketScript.waterInBucket == true)
            {
            if (vannPlayed == false) { 
                source.PlayOneShot(sounds.vann, 1F);
                vannPlayed = true;
                molecules.h2o.transform.localScale = new Vector3(2f, 2f, 2f);
                vannRend.enabled = true;
            }
        }
    }

    void EnableNitrogen() {      
        if (nitrogenPlayed == false)
        {
            source.PlayOneShot(sounds.nitrogen, 1F);
            nitrogenPlayed = true;
            molecules.n.transform.localScale = new Vector3(.01f, .01f, .01f);
            nitrogenRend.enabled = true;
            DisplayHintsScript.hintDisplayed = false;
            DisplayHintsScript.startTime = Time.time;
        }
    }

    void EnableFuel()
    {      
        if (bensinPlayed == false)
        {
            source.PlayOneShot(sounds.fuel, 1F);
            bensinPlayed = true;
            molecules.b8h18.transform.localScale = new Vector3(.002f, .002f, .002f);
            bensinRend.enabled = true;
            DisplayHintsScript.hintDisplayed = false;
            DisplayHintsScript.startTime = Time.time;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(ProfessorScript.tutorialPlayed == true) { 
            if (col.gameObject == objects.bensinkanne)
            {
                EnableFuel();
            }

            if (col.gameObject == objects.grill)
            {
                EnableCarbonmonokside();
            }

            if (col.gameObject == objects.nitrogenlokk)
            {
                EnableNitrogen();
            }
        }

    }
}
