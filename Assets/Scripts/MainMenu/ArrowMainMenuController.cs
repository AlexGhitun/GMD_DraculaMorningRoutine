using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrowMainMenuController : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;

    private RectTransform rect;
    private int currentPosition;

    private float verticalInputCooldown = 0.2f;
    private float lastVerticalInputTime = 0f;

    // Public getter for options (used by UIManager or MainMenuController)
    public RectTransform[] Options => options;

    // Optional: expose current position if needed
    public int CurrentPosition => currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (options.Length > 0)
        {
            currentPosition = 0;
            rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, rect.position.z);
        }
    }

    private void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || verticalAxis > 0.5f) &&
            Time.unscaledTime - lastVerticalInputTime > verticalInputCooldown)
        {
            ChangePosition(-1);
            lastVerticalInputTime = Time.unscaledTime;
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || verticalAxis < -0.5f) &&
            Time.unscaledTime - lastVerticalInputTime > verticalInputCooldown)
        {
            ChangePosition(1);
            lastVerticalInputTime = Time.unscaledTime;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Interact();
        }
    }

    private void ChangePosition(int _change)
    {
        if (_change != 0)
            SoundManager.instance.PlaySound(changeSound);

        currentPosition += _change;

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition >= options.Length)
            currentPosition = 0;

        // Move the arrow
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, rect.position.z);

        // Update the EventSystem selection to the currently highlighted button
        EventSystem.current.SetSelectedGameObject(options[currentPosition].gameObject);
}

    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
