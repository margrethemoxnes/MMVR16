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
    float bucketX;
    float bucketY;
    float bucketZ;


    void Awake()
    {
        boiled = false;
        waterInBucket = false;
        rend = bucketWater.GetComponent<Renderer>();
        bucketX = gameObject.transform.position.x;
        bucketY = gameObject.transform.position.y;
        bucketZ = gameObject.transform.position.z;
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Botte i vann");
        if (col.gameObject == lake)
        {
            if(gameObject.transform.position.y <= 9.7f){
                waterInBucket = true;
                rend.enabled = true;
                degrees.text = "2°C";
            }

            //if(gameObject.transform.position.y < 0)
            //{
            //    gameObject.transform.position = new Vector3(bucketX, bucketY, bucketZ); ;
            //}
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
