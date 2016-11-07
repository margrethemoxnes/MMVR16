using UnityEngine;
using System.Collections;

public class NitrogenScript : MonoBehaviour {

    public GameObject lid;
    public GameObject nitrogenGasContainer;
    public static bool nitrogenOpen;

    float nitrogenX;
    float nitrogenZ;

    private AudioSource source;
    public AudioClip nitrogenIsOpen;

    void Awake() {
        nitrogenX = gameObject.transform.position.x;
        nitrogenZ = gameObject.transform.position.z;
        source = GetComponent<AudioSource>();
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject == lid)
        {
            //Spill av lyd om nitrogen åpen.
            source.PlayOneShot(nitrogenIsOpen, 1F);
            nitrogenOpen = true;
            Instantiate(nitrogenGasContainer, new Vector3(nitrogenX, 10.624f, nitrogenZ), Quaternion.identity);
           
        }
    }

}