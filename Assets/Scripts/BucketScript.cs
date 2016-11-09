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

    private AudioSource source;
    public AudioClip vannetErKokt;

    void Awake()
    {
        boiled = false;
        waterInBucket = false;
        rend = bucketWater.GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject == lake)
        {
            waterInBucket = true;
            rend.enabled = true;
            degrees.text = "2°C";
        }
    }

    void OnCollisionEnter(Collision col) { 
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
