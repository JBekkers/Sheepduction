using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGunscript : MonoBehaviour
{
    public OVRInput.Button ShootButton;
    public OVRInput.Button ReloadButton;
    public Transform FirePoint;
    private RaycastHit hit;

    public bool hideAmmo;
    public float clipSize;
    public float reloadSpeed;
    public float ammoCount;
    public float fireRate;
    public float Damage;
    public Text Ammotxt;
    public AudioSource shootsfx;
    public AudioSource reloadsfx;
    private float cooldown;
    private float clipAmmo;
    private float ammoUsed;

    private void Start()
    {
        Ammotxt = GameObject.FindWithTag("AmmoTXT").GetComponent<Text>() as Text;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        //disable on 0 ammo
        if (clipAmmo <= 0 && ammoCount <= 0)
        {
            gunSwap.instance.guns.Remove(this.gameObject);
            gameObject.SetActive(false);
        }


        if (OVRInput.Get(ShootButton) && cooldown < 0 && clipAmmo > 0)
            {
                if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit))
                {
                    if (hit.transform.gameObject.tag == "ufo")
                    {
                        hit.collider.GetComponent<ufoController>().health -= Damage;
                    }

                if (hit.transform.gameObject.tag == "ScareCrow")
                {
                    WaveSpawner.instance.NextWave = true;
                    Destroy(hit.transform.gameObject);
                }
            }

            cooldown = fireRate;
            shootsfx.Play(0);
            clipAmmo--;
            }

        //auto reload when clip is at 0
        if (clipAmmo == 0 && ammoCount > 0)
        {
            reload();
        }

        //manual reload
        if (OVRInput.Get(ReloadButton) && ammoCount > 0)
        {
            reload();
        }

        if (hideAmmo == true)
        {
            Ammotxt.text = clipAmmo.ToString();
        }
        else Ammotxt.text = clipAmmo.ToString() + "/" + ammoCount.ToString();
    }

    private void reload()
    {
        ammoUsed = clipSize - clipAmmo;
        ammoCount = ammoCount - ammoUsed;
        clipAmmo += ammoUsed;
        while (ammoCount < 0)
        {
            ammoCount++;
            clipAmmo--;
        }
        cooldown = reloadSpeed;
        reloadsfx.Play();
    }
}
