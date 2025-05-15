using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private Vector3 player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(player);
    }
    void Update()
    {             
        transform.position += transform.forward * 1 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Hp -= 1;
        }
        Destroy(this.gameObject);
    }
}
