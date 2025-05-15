using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defaultGun : MonoBehaviour
{
    RaycastHit hit;
    public Text Ammotxt;
    private float cooldown;
    public AudioSource shoot;
    public OVRInput.Button ShootButton;
    public Transform FirePoint;

    void Update()
    {
            //PUT INFINITY SIGN AS AMMO
            Ammotxt.text = "\u221E" + "/" + "\u221E";

        cooldown -= Time.deltaTime;
        //Debug.Log(cooldown);

        if (OVRInput.GetDown(ShootButton) && cooldown < 0)
        {
            shoot.Play(0);
            cooldown = 1f;
            Debug.Log("audio");

            if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit))
            {
                if (hit.transform.gameObject.tag == "ufo")
                {
                    hit.collider.GetComponent<ufoController>().health -= 6;
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0,169,0);
                }

                if (hit.transform.gameObject.tag == "ScareCrow")
                {
                    WaveSpawner.instance.NextWave = true;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
