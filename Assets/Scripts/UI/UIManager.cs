using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private ArrowMenuController arrowMenuController; // Reference to arrow controller

    private void Awake()
    {
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        // Pause toggle with Escape (keyboard) or Start (controller)
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }

        // Simulate pressing a selected menu button with Enter or A
        if (pauseScreen.activeInHierarchy &&
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0)))
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

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
        {
            Time.timeScale = 0;

            EventSystem.current.SetSelectedGameObject(null);

            // Set first selected option based on arrow controller's first option
            if (arrowMenuController != null && arrowMenuController.Options.Length > 0)
            {
                EventSystem.current.SetSelectedGameObject(arrowMenuController.Options[0].gameObject);
            }
        }
        else
        {
            Time.timeScale = 1;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("_MainMenu");
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
