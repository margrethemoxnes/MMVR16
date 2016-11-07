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

    Vector3 NitrogenPos;
    Vector3 CoPos;
    Vector3 O2Pos;
    Vector3 H2oPos;
    Vector3 BensinPos;

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
    bool bensinPlayed;
    bool vannPlayed;
    bool coPlayed;
    bool nitrogenPlayed;
    bool oksygenPlayed;

    public InfoGameObjects planes;
    public MoleculeGameObjects molecules;
    public TriggerObjects objects;
    public InfoSoundGameObjects sounds;

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        source = GetComponent<AudioSource>();
        NitrogenPos = Nitrogen.transform.position;
        CoPos = Co.transform.position;
        O2Pos = O2.transform.position;
        H2oPos = H2O.transform.position;
        BensinPos = Bensin.transform.position;

        bensinRend = planes.bensin.GetComponent<Renderer>();
        vannRend = planes.vann.GetComponent<Renderer>();
        coRend = planes.karbonmonoksid.GetComponent<Renderer>();
        nitrogenRend = planes.nitrogen.GetComponent<Renderer>();
        oksygenRend = planes.oksygen.GetComponent<Renderer>();
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
                    EnableOxygen();
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
            if (col.gameObject == professor)
            {
                Rigidbody profBody = col.gameObject.GetComponent<Rigidbody>();

                if (CasesScripts.ExperimentOne == true)
                {
                    if (professor.transform.position.y == 0) { 
                        Destroy(profBody);
                    }
                }
            }

            if(col.gameObject == objects.bensinkanne)
            {
                EnableFuel();
            }

            if (col.gameObject == objects.grill)
            {
                EnableCarbonmonokside();
            }

            if (col.gameObject == objects.bucket)
            {
                EnableWater();
            }

            if (col.gameObject == objects.nitrogenlokk)
            {
                EnableNitrogen();
            }

            //if (col.gameObject == objects.)
            //{
            //    EnableOxygen();
            //}

            col.attachedRigidbody.isKinematic = false;
            col.gameObject.transform.SetParent(null);

            tossObject(col.attachedRigidbody);

            // Plasser atomer og molekyler på opprinnelig plass
            Nitrogen.transform.position = NitrogenPos;
            H2O.transform.position = H2oPos;
            Co.transform.position = CoPos;
            Bensin.transform.position = BensinPos;
            O2.transform.position = O2Pos;
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
        molecules.o2.transform.localScale = new Vector3(5f, 5f, 5f);
        oksygenRend.enabled = true;
        //if (oksygenPlayed == false)
        //{
        //    source.PlayOneShot(sounds.oksygen, 1F);
        //    oksygenPlayed = true;
        //}
    }

    void EnableCarbonmonokside()
    {
        molecules.co.transform.localScale = new Vector3(.5f, .5f, .5f);
        coRend.enabled = true;
        if (coPlayed == false)
        {
            source.PlayOneShot(sounds.co, 1F);
            coPlayed = true;
        }
    }

    void EnableWater() {
        if(BucketScript.waterInBucket == true) { 
            molecules.h2o.transform.localScale = new Vector3(2f,2f,2f);
            vannRend.enabled = true;
            if (vannPlayed == false)
            {
                source.PlayOneShot(sounds.vann, 1F);
                vannPlayed = true;
            }
        }
    }

    void EnableNitrogen() {
        molecules.n.transform.localScale = new Vector3(.01f, .01f, .01f);
        nitrogenRend.enabled = true;
        if (nitrogenPlayed == false)
        {
            source.PlayOneShot(sounds.nitrogen, 1F);
            nitrogenPlayed = true;
        }
    }

    void EnableFuel()
    {
        molecules.b8h18.transform.localScale = new Vector3(.002f, .002f, .002f);
        bensinRend.enabled = true;
        if (bensinPlayed == false)
        {
            source.PlayOneShot(sounds.fuel, 1F);
            bensinPlayed = true;
        }
    }
}
