using UnityEngine;
using System.Collections;

public class NitrogenScript : MonoBehaviour {

    public GameObject lid;
    public GameObject nitrogenGasContainer;
    public static bool nitrogenOpen;

    float nitrogenX;
    float nitrogenZ;

    void Awake() {
        nitrogenX = gameObject.transform.position.x;
        nitrogenZ = gameObject.transform.position.z;
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject == lid)
        {
            //Start liten røyk animasjon når lokket er tatt av.
            if (nitrogenOpen == false) {
                nitrogenOpen = true;
                Instantiate(nitrogenGasContainer, new Vector3(nitrogenX, 10.624f, nitrogenZ), Quaternion.identity);
            }
        }
    }

}