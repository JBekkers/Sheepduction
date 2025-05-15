using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Hand"))
        {
            anim.Play("MenuButton");

            SceneManager.LoadScene(1);
            WaveSpawner.instance.GameEnd = false;
        }
    }
}
