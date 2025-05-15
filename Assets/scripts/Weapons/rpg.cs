using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rpg : MonoBehaviour
{
    private float cooldown;
    public AudioSource shoot;
    public GameObject rocketLauncher;
    private GameObject rocket;
    public GameObject prefab;
    public OVRInput.Button ShootButton;
    public OVRInput.Button ReloadButton;
    private int speed = 85000;

    private float ammoUsed;
    public Text Ammotxt;
    public AudioSource reloadsfx;
    private float clip;
    public float ammo;
    private bool reloading;
    private float reloadTimer = 0;
    public Transform FirePoint;


    void Update()
    {
        //disable on 0 ammo
        if (clip <= 0 && ammo <= 0)
        {
            gunSwap.instance.guns.Remove(this.gameObject);
            gameObject.SetActive(false);
        }

        Ammotxt.text = clip.ToString() + "/" + ammo.ToString();

        cooldown -= Time.deltaTime;

        if (reloading) reloadTimer += Time.deltaTime;
        if (reloadTimer > 1)
        {
            if (ammo > 0)
            {
                reloadsfx.Play();
                clip++;
                ammo--;
                if (clip == 10) reloading = false;
            } else
            {
                reloading = false;
            }
            reloadTimer = 0;
        }

        if (OVRInput.Get(ShootButton) && cooldown < 0 && clip > 0)
        {
            rocket = Instantiate(prefab, new Vector3(0, 0f, 0f), Quaternion.identity) as GameObject;
            Transform parent = rocketLauncher.GetComponent<Transform>();
            rocket.transform.position = parent.position;
            rocket.transform.rotation = parent.rotation;
            rocket.GetComponent<Rigidbody>().AddForce(FirePoint.forward * speed * Time.deltaTime);
            shoot.Play();
            cooldown = 2;

            reloading = false;
            reloadTimer = 0;

            clip--;
        }

        //auto reload
        if (clip == 0)
        {
            reload();
        }

        //manual reload
        if (OVRInput.Get(ReloadButton))
        {
            reload();
        }
    }

    private void reload()
    {
        reloading = true;
    }
}
