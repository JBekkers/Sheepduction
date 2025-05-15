using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerinfo : MonoBehaviour
{
    public GameObject barrier;
    public static controllerinfo instance { get; private set; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Text rx;
    public Text ry;
    public Text rz;
    public Text rv;

    public Text lx;
    public Text ly;
    public Text lz;
    public Text lv;

    public Text intnumber;
    public Text yesno;
    public bool test;

    void Update()
    {
        rx.text = "rx " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand).eulerAngles.x.ToString();
        ry.text = "ry " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand).eulerAngles.y.ToString();
        rz.text = "rz " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand).eulerAngles.z.ToString();
        rv.text = "right vel: " + OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand).ToString();

        lx.text = "lx " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.LHand).eulerAngles.x.ToString();
        ly.text = "ly " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.LHand).eulerAngles.y.ToString();
        lz.text = "lz " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.LHand).eulerAngles.z.ToString();
        lv.text = "left vel: " + OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LHand).ToString();

        intnumber.text = barrier.GetComponent<BarrierController>().hp.ToString();
        if (test) { yesno.text = "yes.mp3"; }
        else yesno.text = "nope.avi";
    }
}
