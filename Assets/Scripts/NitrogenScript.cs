using UnityEngine;
using System.Collections;

public class NitrogenScript : MonoBehaviour {

    public GameObject lid;
    public GameObject nitrogenGasContainer;
    public static bool nitrogenOpen;

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject == lid)
        {
            //Spill av lyd om nitrogen åpen.
            nitrogenOpen = true;
            Instantiate(nitrogenGasContainer, new Vector3(3.0f, 1.0f, 1.52f), Quaternion.identity);
           
        }
    }

}