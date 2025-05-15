using UnityEngine;

public class WatchController : MonoBehaviour
{
    public GameObject UIinfo;

    void Update()
    {
        if(OVRInput.GetLocalControllerRotation(OVRInput.Controller.LHand).eulerAngles.z >= 160 && OVRInput.GetLocalControllerRotation(OVRInput.Controller.LHand).eulerAngles.z <= 205)
        {
            UIinfo.SetActive(true);
        }
        else UIinfo.SetActive(false);
    }
}
