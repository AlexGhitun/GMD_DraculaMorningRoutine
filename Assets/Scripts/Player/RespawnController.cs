using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private HealthController playerHealth;
    
    private void Awake()
    {
        playerHealth = GetComponent<HealthController>();
    }

    public void Respawn()
    {
        Debug.Log("Respawn() called in RespawnController.");

        if (currentCheckpoint == null)
        {
            Debug.LogError("Respawn failed: currentCheckpoint is null!");
            return;
        }

        Debug.Log("Respawning at checkpoint: " + currentCheckpoint.name);

        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }


    //Activate checkpoints
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "DoorCheckpoint")
        {
            currentCheckpoint = collision.transform;
            Debug.Log("Checkpoint activated: " + currentCheckpoint.name);

            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("openDoor");
        }
    }

}
