using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDrink : MonoBehaviour
{
    private ParticleSystem particle;
    public RaycastHit hit;
    public int uses;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if (OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand).eulerAngles.x <= 300 && OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand).eulerAngles.x >= 15)
        {
            particle.Play();
            if(Physics.Raycast(transform.position, Vector3.up,out hit) && hit.transform.CompareTag("Player") && uses > 0)
            {
                hit.transform.GetComponent<PlayerHealth>().Hp += 1;
                uses -= 1; 
            }
        }
    }
}
