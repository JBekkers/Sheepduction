using UnityEngine;

public class forkHit : MonoBehaviour
{
    public float timer = 4;
    public bool Trown;

    private void Update()
    {
        if (Trown)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("ufo"))
        {
            //Debug.Log(col.gameObject);
            col.gameObject.GetComponent<ufoController>().health -= 20f;
            Destroy(this.gameObject);
        }
    }
}
