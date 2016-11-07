using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class OpenBookScript : MonoBehaviour {
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    float scale = 3.0f;

    public GameObject book;

    bool firstOpen;
    private AudioSource source;
    public AudioClip fantBoken;

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        book.transform.SetParent(gameObject.transform);
        firstOpen = false;
        source = GetComponent<AudioSource>();
    }

    void OpenBook() {
        book.transform.localScale = new Vector3(scale, scale, scale);
    }

    void CloseBook()
    {
        book.transform.localScale = Vector3.zero;
    }

    void FixedUpdate() {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            OpenBook();
            if (firstOpen == false) {
                firstOpen = true;
                source.PlayOneShot(fantBoken, 1F);
            }
        }
        
        if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            CloseBook();
        }
    }
}
