using UnityEngine;
using System.Collections;

public class BucketScript : MonoBehaviour {

    public static bool waterInBucket;
    public GameObject lake;
    public GameObject campfire;
    public TextMesh degrees;
    public static bool boiled;
    private Renderer rend;
    public GameObject bucketWater;


    void Awake()
    {
        boiled = false;
        waterInBucket = false;
        rend = bucketWater.GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Botte i vann");
        if (col.gameObject == lake)
        {
            if(gameObject.transform.position.y < 10.22f){
                waterInBucket = true;
                rend.enabled = true;
                degrees.text = "2°C";
            }
        }
 
        if (col.gameObject == campfire)
        {
            //Spill av lyd. Fullført koking av vann.
            if (waterInBucket == true)
            {
                degrees.text = "100°C";
                boiled = true;
            }
        }
    }
}
