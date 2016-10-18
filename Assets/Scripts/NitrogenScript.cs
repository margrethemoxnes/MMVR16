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
            //Spill av lyd om nitrogen åpen.
            nitrogenOpen = true;
            Instantiate(nitrogenGasContainer, new Vector3(nitrogenX, 11.22f, nitrogenZ), Quaternion.identity);
           
        }
    }

}