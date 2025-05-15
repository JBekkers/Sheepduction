using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
