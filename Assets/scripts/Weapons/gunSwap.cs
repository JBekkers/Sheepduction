using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwap : MonoBehaviour
{
    public List<GameObject> guns;
    public OVRInput.Button Left;
    public OVRInput.Button Right;
    public GameObject selected;
    public float select;

    public static gunSwap instance { get; private set; }
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

    void Update()
    {
        //scrolling inventory
        if (OVRInput.GetDown(Left)) { select -= 1; }
        if (OVRInput.GetDown(Right)) { select += 1; }


        if (select > guns.Count - 1) select -= guns.Count;
        if (select < 0f) select += guns.Count;
        selected = guns[Mathf.FloorToInt(select)];
        foreach (GameObject o in guns)
        {
            if (o == selected) 
            { 
                o.SetActive(true); 
            }
            else { o.SetActive(false); }
        } 
    }
}
