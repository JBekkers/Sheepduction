using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrowWeapons : MonoBehaviour
{
    public GameObject Projectile;
    public OVRInput.Button TrowButton;
    public int Speed = 4;

    public GameObject GunModel;
    private GameObject Proj;

    public float clipAmmo;
    public float fireRate;
    public Text Ammotxt;
    public AudioSource shootsfx;
    private float cooldown;

    void Update()
    {
        Ammotxt.text = clipAmmo.ToString();
        cooldown -= Time.deltaTime;

        //get down to spawn in a duck once
        if (OVRInput.GetDown(TrowButton) && cooldown < 0 && clipAmmo > 0)
        {
           Proj = Instantiate(Projectile, new Vector3(0, 0f, 0f), Quaternion.identity) as GameObject;
        }
       
        //let the duck follow movements
        if (OVRInput.Get(TrowButton))
        {
        Transform parent = GunModel.GetComponent<Transform>();
        Proj.transform.position = parent.position;
        Proj.transform.rotation = parent.rotation;
        }

        //trow the duck away :(
        if (OVRInput.GetUp(TrowButton))
        {
            //mark projectile as being trown
            Proj.GetComponent<duckExplode>().Trown = true;
            Proj.GetComponent<Rigidbody>().isKinematic = false;       
            Proj.GetComponent<Rigidbody>().velocity = transform.TransformDirection(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch)) * Speed;
            Proj.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
            shootsfx.Play();
            cooldown = fireRate;
            clipAmmo--;
        }
    }
}
