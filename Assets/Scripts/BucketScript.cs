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

    private AudioSource source;
    public AudioClip vannetErKokt;

    void Awake()
    {
        boiled = false;
        waterInBucket = false;
        rend = bucketWater.GetComponent<Renderer>();
        bucketX = gameObject.transform.position.x;
        bucketY = gameObject.transform.position.y;
        bucketZ = gameObject.transform.position.z;
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == lake)
        {
            if(gameObject.transform.position.y <= 9.7f){
                waterInBucket = true;
                rend.enabled = true;
                degrees.text = "2°C";
            }
        }
 
        if (col.gameObject == campfire)
        {
            if (waterInBucket == true)
            {
                degrees.text = "100°C";
                boiled = true;
                source.PlayOneShot(vannetErKokt, 1F);
            }
        }
    }
}
