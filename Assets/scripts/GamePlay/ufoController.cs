using Oculus.Platform.Samples.VrHoops;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ufoController : MonoBehaviour
{
    public float health;
    public float speed;
    public GameObject Lazer;
    public int coinsnum;
    public bool CanShoot;
    private float cooldown = 3;

    public GameObject target;
    public GameObject ufo;
    public LineRenderer line;
    public GameObject player;
    public Material mat;
    private float shoot;

    RaycastHit hit;
    private float timer = 0;

    private void Start()
    {
        WaveSpawner.instance.ufoLeft.Add(gameObject);
        ufo = this.gameObject;
        line = gameObject.GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        mat = line.material;
    }
    void Update()
    {
        Debug.DrawRay(transform.position, (player.transform.position - transform.position));

        if (CanShoot)
        {
            shoot += Time.deltaTime;
            mat.color = Color.green;

            if (shoot > 3 && shoot < 6)
            {
                mat.color = Color.yellow;
            }

            if (shoot > 6)
            {
                mat.color = Color.red;
                line.gameObject.GetComponent<LineRenderer>().enabled = false;
                CanShoot = false;

                if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        player.GetComponent<PlayerHealth>().Hp -= 1;
                    }

                    if (hit.transform.parent.CompareTag("Barrier"))
                    {
                        hit.transform.parent.gameObject.GetComponent<BarrierController>().hp -= 1;
                    }
                }
            }

            line.SetPosition(0, transform.position);
            line.SetPosition(1, player.transform.position);
        }


        if (health > 0)
        {
            timer += Time.deltaTime;
            target.GetComponent<Rigidbody>().AddForce((transform.position - target.transform.position) * Time.deltaTime * speed * timer);
        }
        else if (health <0 && health >-6000)
        {
            coinsnum = Random.Range(60,110);
            WaveSpawner.instance.Animallist.Add(target);
            Destroy(this.gameObject);
            WaveSpawner.instance.ufoLeft.Remove(gameObject);
            VRShopController.instance.coins += coinsnum; 
        }
        else if (health <= -6969)
        {
            CanShoot = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up);
            if (transform.position.y > 50f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("animal"))
        {
            WaveSpawner.instance.ufoLeft.Remove(gameObject);
            Destroy(coll.gameObject);
            health = -6969;
        }
    }
}
