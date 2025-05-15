using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class BarrierRepair : MonoBehaviour
{
    [SerializeField] public int uses;
    public Text Ammotxt;

    private void Update()
    {
        Ammotxt.text = uses.ToString();
    }

    private void OnTriggerEnter(Collider coll)
    {
        //Debug.Log(coll);

        if (coll.transform.parent.CompareTag("Barrier") && uses > 0)
        {
            if (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand).y < -2.5f)
            {
                coll.gameObject.GetComponentInParent<BarrierController>().hp += 1;
                uses -= 1;
            }
        }

        //disable on 0 uses
        if (uses <= 0)
        {
            gunSwap.instance.guns.Remove(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
