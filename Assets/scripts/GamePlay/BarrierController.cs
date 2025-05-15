using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public int hp = 6;
    public Material Normal;
    public Material Cracked;

    public MeshRenderer barrierObject;

    void Update()
    {
        switch (hp)
        {
            case 6:
                barrierObject.GetComponent<MeshRenderer>().material = Normal;
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                break;
            case 5:
                barrierObject.GetComponent<MeshRenderer>().material = Cracked;
                break;
            case 4:
                barrierObject.GetComponent<MeshRenderer>().material = Normal;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                break;
            case 3:
                barrierObject.GetComponent<MeshRenderer>().material = Cracked;
                break;
            case 2:
                barrierObject.GetComponent<MeshRenderer>().material = Normal;
                transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
                break;
            case 1:
                barrierObject.GetComponent<MeshRenderer>().material = Cracked;
                break;
            default:
                break;
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Lazer"))
        {
            hp -=1;
        }
    }
}
