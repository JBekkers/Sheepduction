using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public float timer = 20;
    private Vector3 sphereLocation;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        sphereLocation = col.transform.gameObject.transform.position;
        Collider[] hitcol = Physics.OverlapSphere(sphereLocation, 30);
            foreach (Collider hit in hitcol)
            {
                if (hit.gameObject.CompareTag("ufo"))
                {
                    hit.gameObject.GetComponent<ufoController>().health -= 20f;

                }

                if (hit.gameObject.CompareTag("ScareCrow"))
                {
                    WaveSpawner.instance.NextWave = true;
                    Destroy(hit.gameObject);
                }
            }                             
            Destroy(this.gameObject);      
    }
}
