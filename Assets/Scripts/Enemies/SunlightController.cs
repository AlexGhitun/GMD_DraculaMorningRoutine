using UnityEngine;

public class SunlightController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthController>().Vulnerable(true); // Entering light
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthController>().Vulnerable(false); // Exiting light
        }
    }
}
