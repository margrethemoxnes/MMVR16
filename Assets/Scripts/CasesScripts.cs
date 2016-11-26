using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CasesScripts : MonoBehaviour {

    public static int experiment;

    public static bool ExperimentOne;
    public static bool ExperimentTwo;
    public static bool ExperimentThree;
    public static bool ExperimentFour;
    public static bool ExperimentFive;

    AudioSource source;

    //private UnityAction onSaved;
    //private UnityAction onExploded;
    //private UnityAction onSmallGas;
    //private UnityAction onPoofed;



    //void ProfessorScript_OnSaved()
    //{
    //    experiment = 2;
    //    ExperimentOne = true;
    //    //TurnOffStatic();
    //    eureka1.text = "Eureka! Now experiment " + experiment;
    //}

    //void BensinScript_OnExploded()
    //{

    //    ExperimentTwo = true;
    //    //Spill av fullført eksperiment lyd
    //    eureka1.text = "kaboom!";
    //    if (ExperimentThree == true)
    //    {
    //        experiment = 4;
    //    }
    //    else {
    //        experiment = 3;
    //    }
    //}

    //void NitrogenScript_OnSmallSmoke()
    //{
    //    ExperimentThree = true;
    //    eureka1.text = "Nitrogen i vann";
    //    if (ExperimentTwo == true) {
    //        experiment = 4;
    //    }
    //    else {
    //        experiment = 2;
    //    }    
    //    //Spill av fullført eksperiment lyd
    //}

    //void BaljeScript_OnPoofed()
    //{
    //    //throw new System.NotImplementedException();
    //    eureka1.text = "Takk for at du spilte";
    //    ExperimentFour = true;
    //    if (ExperimentTwo == false)
    //    {
    //        experiment = 2;
    //    }
    //    else if (ExperimentThree == false)
    //    {
    //        experiment = 3;
    //    }
    //    else {
    //        //Spill av fullført demo lyd
    //    }
    //}


    // Use this for initialization
    void Awake () {
        experiment = 1;
        ExperimentOne = false;
        ExperimentTwo = false;
        ExperimentThree = false;
        ExperimentFour = false;
        ExperimentFive = false;
        //onSaved = new UnityAction(OnSaved);
        //onExploded = new UnityAction(OnExploded);
        //onSmallGas = new UnityAction(OnSmallSmoke);
        //onPoofed = new UnityAction(OnPoofed);
        //TurnOffStatic();
    }
    /*
    void OnEnabled()
    {
        //ProfessorScript.OnSaved += ProfessorScript_OnSaved;
        //BensinScript.OnExploded  += BensinScript_OnExploded;
        //LakeScript.OnSmallSmoke += NitrogenScript_OnSmallSmoke;
        //BaljeScript.OnPoofed += BaljeScript_OnPoofed;

        EventManager.StartListening("OnSaved", OnSaved);
        EventManager.StartListening("OnExploded", OnExploded);
        EventManager.StartListening("OnSmallSmoke", OnSmallSmoke);
        EventManager.StartListening("OnPoofed", OnPoofed);
    }

    void OnDisabled()
    {
        //ProfessorScript.OnSaved -= ProfessorScript_OnSaved;
        //BensinScript.OnExploded -= BensinScript_OnExploded;
        //LakeScript.OnSmallSmoke -= NitrogenScript_OnSmallSmoke;
        //BaljeScript.OnPoofed -= BaljeScript_OnPoofed;

        EventManager.StopListening("OnSaved", OnSaved);
        EventManager.StopListening("OnExploded", OnExploded);
        EventManager.StopListening("OnSmallSmoke", OnSmallSmoke);
        EventManager.StopListening("OnPoofed", OnPoofed);
    }


    // Update is called once per frame
    //void FixedUpdate () {   
    //    switch (experiment) {
    //        case 1:
    //            break;
    //        case 2:
    //            //eureka1.text = "Eureka! Now experiment " + experiment;
    //            break;
    //        case 3:
    //            //eureka1.text = "Kaboom! Now experiment " + experiment;
    //            break;
    //        case 4:
    //            eureka1.text = "Eureka! Small gascloud. Now Experiment " + experiment;
    //            //Spill av fullført lyd. Takk for hjelpen.
    //            break;
    //    }

    //if (Time.time > 10) {
    //    Debug.Log("10 sec gått");
    //}

    //}
    */
    

    /*
    void OnSaved()
    {
        experiment = 2;
        ExperimentOne = true;
        //TurnOffStatic();
        eureka1.text = "Eureka! Now experiment " + experiment;
    }

    void OnExploded()
    {

        ExperimentTwo = true;
        //Spill av fullført eksperiment lyd
        eureka1.text = "kaboom!";
        if (ExperimentThree == true)
        {
            experiment = 4;
        }
        else
        {
            experiment = 3;
        }
    }

    void OnSmallSmoke()
    {
        ExperimentThree = true;
        eureka1.text = "Nitrogen i vann. Hurra!";
        if (ExperimentTwo == true)
        {
            experiment = 4;
        }
        else
        {
            experiment = 2;
        }
        //Spill av fullført eksperiment lyd
    }

    void OnPoofed()
    {
        //throw new System.NotImplementedException();
        eureka1.text = "Takk for at du spilte";
        ExperimentFour = true;
        if (ExperimentTwo == false)
        {
            experiment = 2;
        }
        else if (ExperimentThree == false)
        {
            experiment = 3;
        }
        else
        {
            //Spill av fullført demo lyd
        }
    }*/
}
