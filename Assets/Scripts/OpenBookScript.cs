using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class OpenBookScript : MonoBehaviour {
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public GameObject book;

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        book.transform.SetParent(gameObject.transform);
    }

    void OpenBook() {
        book.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
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
        }
        
        if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            CloseBook();
        }
    }
}
