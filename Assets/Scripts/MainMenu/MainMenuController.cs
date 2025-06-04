using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private ArrowMainMenuController arrowMenuController; // Your arrow selector script

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        if (arrowMenuController != null && arrowMenuController.Options.Length > 0)
        {
            EventSystem.current.SetSelectedGameObject(arrowMenuController.Options[0].gameObject);
        }
    }

    private void Update()
    {
        // Accept input with keyboard Enter or controller A
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            GameObject selected = EventSystem.current.currentSelectedGameObject;
            if (selected != null)
            {
                var pointer = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(selected, pointer, ExecuteEvents.submitHandler);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
