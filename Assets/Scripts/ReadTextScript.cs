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

    
    [System.Serializable]
    public class infoMaterials { 
        public Material txtBensin;
        public Material txtVann;
        public Material txtCo;
        public Material txtNitrogen;
        public Material txtOksygen;
    }

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
    public infoMaterials materials;
    public infoAudio audio;

    // Use this for initialization
    void Awake () {
        bensinPlayed = false;
        source = GetComponent<AudioSource>();
        bensinRend = planes.bensinPlane.GetComponent<Renderer>();
        vannRend = planes.vannPlane.GetComponent<Renderer>();
        coRend = planes.coPlane.GetComponent<Renderer>();
        nitrogenRend = planes.nitrogenPlane.GetComponent<Renderer>();
        oksygenRend = planes.oksygenPlane.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject == colliders.bensin)
        {
            if (bensinPlayed == false) {
                source.PlayOneShot(audio.infoBensin, 1F);
                bensinPlayed = true;
                bensinRend.material = materials.txtBensin;
            }
        }

        if (col.gameObject == colliders.vann)
        {
            if (vannPlayed == false)
            {
                source.PlayOneShot(audio.infoVann, 1F);
                vannPlayed = true;
                vannRend.material = materials.txtVann;
            }
        }

        if (col.gameObject == colliders.co)
        {
            if (coPlayed == false)
            {
                source.PlayOneShot(audio.infoCo, 1F);
                coPlayed = true;
                coRend.material = materials.txtCo;
            }
        }

        if (col.gameObject == colliders.nitrogen)
        {
            if (nitrogenPlayed == false)
            {
                source.PlayOneShot(audio.infoNitrogen, 1F);
                nitrogenPlayed = true;
                nitrogenRend.material = materials.txtNitrogen;
            }
        }

        if (col.gameObject == colliders.oksygen)
        {
            if (oksygenPlayed == false)
            {
                source.PlayOneShot(audio.infoOksygen, 1F);
                oksygenPlayed = true;
                oksygenRend.material = materials.txtOksygen;
            }
        }
    }
}
