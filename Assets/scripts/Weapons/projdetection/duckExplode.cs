using UnityEngine;

public class duckExplode : MonoBehaviour
{
    private float timer = 2;
    private Vector3 sphereLocation;
    public bool Trown;
    public AudioSource explode;

    private void Update()
    {
        if (Trown)
        {
            //Debug.Log(timer);
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            sphereLocation = transform.position;
            Collider[] hitcol = Physics.OverlapSphere(sphereLocation, 25);
            explode.Play();

            foreach (Collider hit in hitcol)
            {
                if (hit.gameObject.CompareTag("ufo"))
                {
                    hit.gameObject.GetComponent<ufoController>().health -= 20f;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
