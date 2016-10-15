using UnityEngine;
using System.Collections;

public class BucketScript : MonoBehaviour {

    public static bool waterInBucket;
    public GameObject lake;
    public GameObject campfire;
    public TextMesh degrees;
    public static bool boiled;

    public TextMesh eureka;

    void Awake()
    {
        boiled = false;
        waterInBucket = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == lake)
        {
            waterInBucket = true;
            degrees.text = "2°C";
            //Materialet byttes til vann i bøtta
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
