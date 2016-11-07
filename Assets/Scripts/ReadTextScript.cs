using UnityEngine;
using System.Collections;

public class ReadTextScript : MonoBehaviour {

    [System.Serializable]
    public class ColliderGameObjects{
        public GameObject bensin;
        public GameObject vann;
        public GameObject co;
        public GameObject nitrogen;
        public GameObject oksygen;
    }

    [System.Serializable]
    public class objectPlanes {
        public GameObject bensinPlane;
        public GameObject vannPlane;
        public GameObject coPlane;
        public GameObject nitrogenPlane;
        public GameObject oksygenPlane;
    }

    
    //[System.Serializable]
    //public class infoMaterials { 
    //    public Material txtBensin;
    //    public Material txtVann;
    //    public Material txtCo;
    //    public Material txtNitrogen;
    //    public Material txtOksygen;
    //}

    [System.Serializable]
    public class infoAudio { 
        public AudioClip infoBensin;
        public AudioClip infoVann;
        public AudioClip infoCo;
        public AudioClip infoNitrogen;
        public AudioClip infoOksygen;
    }

    private AudioSource source;

    // played bools
    bool bensinPlayed;
    bool vannPlayed;
    bool coPlayed;
    bool nitrogenPlayed;
    bool oksygenPlayed;

    // Renderers
    private Renderer bensinRend;
    private Renderer vannRend;
    private Renderer coRend;
    private Renderer nitrogenRend;
    private Renderer oksygenRend;

    public ColliderGameObjects colliders;
    public objectPlanes planes;
    //public infoMaterials materials;
    public infoAudio theInfoAudio;

    float hmdY;

    // Use this for initialization
    void Awake () {
        hmdY = (gameObject.transform.position.y) + 100;
        bensinPlayed = false;
        source = GetComponent<AudioSource>();
        bensinRend = planes.bensinPlane.GetComponent<Renderer>();
        vannRend = planes.vannPlane.GetComponent<Renderer>();
        coRend = planes.coPlane.GetComponent<Renderer>();
        nitrogenRend = planes.nitrogenPlane.GetComponent<Renderer>();
        oksygenRend = planes.oksygenPlane.GetComponent<Renderer>();

        // Sett høyde lik camera
        planes.bensinPlane.transform.Translate(transform.position.x, hmdY, transform.position.z);
        planes.nitrogenPlane.transform.Translate(transform.position.x, hmdY, transform.position.z);
        planes.coPlane.transform.Translate(transform.position.x, hmdY, transform.position.z);
        planes.oksygenPlane.transform.Translate(transform.position.x, hmdY, transform.position.z);
        planes.vannPlane.transform.Translate(transform.position.x, hmdY, transform.position.z);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject == colliders.bensin)
        {
            if (bensinPlayed == false) {
                source.PlayOneShot(theInfoAudio.infoBensin, 1F);
                bensinPlayed = true;
                bensinRend.enabled = true;
            }
        }

        if (col.gameObject == colliders.vann)
        {
            if (vannPlayed == false)
            {
                source.PlayOneShot(theInfoAudio.infoVann, 1F);
                vannPlayed = true;
                vannRend.enabled = true;
            }
        }

        if (col.gameObject == colliders.co)
        {
            if (coPlayed == false)
            {
                source.PlayOneShot(theInfoAudio.infoCo, 1F);
                coPlayed = true;
                coRend.enabled = true;
            }
        }

        if (col.gameObject == colliders.nitrogen)
        {
            if (nitrogenPlayed == false)
            {
                source.PlayOneShot(theInfoAudio.infoNitrogen, 1F);
                nitrogenPlayed = true;
                nitrogenRend.enabled = true;
            }
        }

        if (col.gameObject == colliders.oksygen)
        {
            if (oksygenPlayed == false)
            {
                source.PlayOneShot(theInfoAudio.infoOksygen, 1F);
                oksygenPlayed = true;
                oksygenRend.enabled = true;
            }
        }
    }
}
