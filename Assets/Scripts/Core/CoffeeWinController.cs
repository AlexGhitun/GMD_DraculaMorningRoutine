using UnityEngine;

public class CoffeeWinController : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    private void Awake()
    {
        winScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Win!");
            if (winScreen != null)
            {
                winScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
