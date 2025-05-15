using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRShopController : MonoBehaviour {

    public OVRInput.Button BuyButton;

    public AudioSource buy;

    public int coins;
    public Text coinstxt;

    public GameObject AWP;
    public GameObject AK74;
    public GameObject MiniGun;
    public GameObject Ducknate;
    public GameObject Hayfork;
    public GameObject Rpg;
    public GameObject Barrierkit;
    public GameObject HealItem;

    public Transform FirePoint;
    private RaycastHit hit;

    public static VRShopController instance { get; private set; }

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

    public void Update()
    {
        coinstxt.text = "$" + coins.ToString();
        //Debug.Log(coins);

        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit) && hit.distance < 10)
        {
            if (hit.collider.CompareTag("awp") && coins >= 800)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 800;
                    AWP.GetComponent<VRGunscript>().ammoCount += 25;
                    gunSwap.instance.guns.Add(AWP);
                    buy.Play();
                }
            }

            if (hit.transform.gameObject.tag == "ak" && coins >= 550)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 550;
                    AK74.GetComponent<VRGunscript>().ammoCount += 75;
                    gunSwap.instance.guns.Add(AK74);
                    buy.Play();
                }
            }

            if (hit.collider.CompareTag("hayfork") && coins >= 90)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 90;
                    Hayfork.GetComponent<TrowWeapons>().clipAmmo += 20;
                    gunSwap.instance.guns.Add(Hayfork);
                    buy.Play();
                }
            }

            if (hit.collider.CompareTag("ducknate") && coins >= 250)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 250;
                    Ducknate.GetComponent<TrowWeapons>().clipAmmo += 15;
                    gunSwap.instance.guns.Add(Ducknate);
                    buy.Play();
                }
            }

            if (hit.collider.CompareTag("minigun") && coins >= 500)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 500;
                    MiniGun.GetComponent<VRGunscript>().ammoCount += 170;
                    gunSwap.instance.guns.Add(MiniGun);
                    buy.Play();
                }
            }

            if (hit.collider.CompareTag("rpg") && coins >= 300)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 300;
                    Rpg.GetComponent<rpg>().ammo += 30;
                    gunSwap.instance.guns.Add(Rpg);
                    buy.Play();
                }
            }

            if (hit.collider.CompareTag("healitem") && coins >= 3000)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 3000;
                    //HealItem.GetComponent<HealingDrink>().use += 30;
                    gunSwap.instance.guns.Add(HealItem);
                    buy.Play();
                }
            }

            if (hit.collider.CompareTag("barrierkit") || Input.GetKey(KeyCode.L) && coins >= 2000)
            {
                if (OVRInput.GetDown(BuyButton))
                {
                    coins -= 2000;
                    Barrierkit.GetComponent<BarrierRepair>().uses += 2;
                    gunSwap.instance.guns.Add(Barrierkit);
                    buy.Play();
                }
            }
        }
    }
}