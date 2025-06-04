using UnityEngine;

public class SpikesController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthController>().Death();
        }
    }
}
