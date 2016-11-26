using UnityEngine;
using System.Collections;

public class DisplayExperiments : MonoBehaviour {

    public static int experimentsDone;

    public Material eks1;
    public Material eks2;
    public Material eks3;
    public Material eks5;
    public Material eks6;
    public Material eks7;
    public Material eks8;
    public Material eks9;
    public Material eks10;
    public Material eks11;
    public Material eks12;

    Renderer render;


    // Use this for initialization
    void Awake () {
	    render = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Aktiver materialet utifra aktivt experiment
        switch (experimentsDone)
        {
            case 1:
                render.material = eks1;
                break;
            case 2:
                render.material = eks2;
                break;
            case 3:
                render.material = eks3;
                break;
            case 5:
                render.material = eks5;
                break;
            case 6:
                render.material = eks6;
                break;
            case 7:
                render.material = eks7;
                break;
            case 8:
                render.material = eks8;
                break;
            case 9:
                render.material = eks9;
                break;
            case 10:
                render.material = eks10;
                break;
            case 11:
                render.material = eks11;
                break;
            case 12:
                render.material = eks12;
                break;
        }

    }


}
