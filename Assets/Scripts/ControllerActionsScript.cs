using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerActionsScript : MonoBehaviour {

    public GameObject professor;
    public GameObject Co;
    public GameObject atv;
    public AudioClip ikkedra;
    bool ikkeDra;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    private AudioSource source;

    // Info - Lyd
    [System.Serializable]
    public class InfoSoundGameObjects{
        public AudioClip vann;
        public AudioClip nitrogen;
        public AudioClip fuel;
        public AudioClip co;
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
        public GameObject o2;
        public GameObject co;
    }

    
    // Renderers
    private Renderer bensinRend;
    private Renderer coRend;
    private Renderer nitrogenRend;


    // played bools
    public static bool bensinPlayed;
   
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
        coRend = planes.karbonmonoksid.GetComponent<Renderer>();
        nitrogenRend = planes.nitrogen.GetComponent<Renderer>();
        ikkeDra = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!source.isPlaying)
        {
            device = SteamVR_Controller.Input((int)trackedObj.index);
        }
        
    }

    //Plukk opp
    void OnTriggerStay(Collider col)
    {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (col.gameObject == professor || col.gameObject == objects.grill || col.gameObject == objects.o2 || col.gameObject == objects.co)
            {
                if (CasesScripts.experiment != 1 && col.gameObject == professor)
                {
                    
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
           
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;

            if (col.gameObject.tag == "Molecule")
            {
               
            }
            else {
                tossObject(col.attachedRigidbody);
            }
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

    void EnableCarbonmonokside()
    {   
        if (coPlayed == false)
        {
            source.PlayOneShot(sounds.co, 1F);
            coPlayed = true;
            molecules.co.transform.localScale = new Vector3(.3f, .3f, .3f);
            coRend.enabled = true;
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

    void IkkeDra() {
        if (ikkeDra == false) {
            source.PlayOneShot(ikkedra, 1F);
            ikkeDra = true;
        }
    }



    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject == objects.grill)
        {
            EnableCarbonmonokside();
        }

       

        if (ProfessorScript.tutorialPlayed == true) {    


            if (col.gameObject == objects.nitrogenlokk)
            {
                EnableNitrogen();
            }

            if (col.gameObject == objects.bensinkanne)
            {
                EnableFuel();
            }

            if (col.gameObject == atv)
            {
                IkkeDra();
            }
        }


    }
}
