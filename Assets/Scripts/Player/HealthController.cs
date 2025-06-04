using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float alive;
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    private PlayerMovement playerMovement;

    // === NEW LIGHT-RELATED VARIABLES ===
    private bool inSunlight = false;
    private float sunlightTimer = 0f;
    [SerializeField] private float timeToDie = 3f;
    private Coroutine blinkingCoroutine;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (inSunlight && !dead)
        {
            sunlightTimer += Time.deltaTime;

            if (sunlightTimer >= timeToDie)
            {
                StopBlinking();
                Death();
            }
        }
    }

    private IEnumerator Invulnerability()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1);
            spriteRend.color = Color.white;
        }
    }

    public void Death()
    {
        if (!dead)
        {
            Debug.Log("Player has died.");

            anim.SetTrigger("die");

            if (playerMovement != null)
                playerMovement.enabled = false;

            foreach (Behaviour component in components)
            {
                component.enabled = false;
                Debug.Log("Disabled component: " + component.GetType().Name);
            }

            dead = true;
            SoundManager.instance.PlaySound(deathSound);

            StartCoroutine(HandleRespawn());
        }
    }

    public void Vulnerable(bool status)
{
    Debug.Log("Vulnerable called: " + status);

    inSunlight = status;

    if (inSunlight)
    {
        sunlightTimer = 0f;
        StartBlinking();
    }
    else
    {
        StopBlinking();
        sunlightTimer = 0f;
    }
}

    private void StartBlinking()
    {
        if (blinkingCoroutine != null) StopCoroutine(blinkingCoroutine);
        blinkingCoroutine = StartCoroutine(BlinkRed());
    }

    private void StopBlinking()
    {
        if (blinkingCoroutine != null) StopCoroutine(blinkingCoroutine);
        spriteRend.color = Color.white;
    }

    private IEnumerator BlinkRed()
    {
        while (inSunlight && !dead)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.2f);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator HandleRespawn()
    {
        yield return new WaitForSeconds(2f); // Match death animation duration

        Debug.Log("Respawn coroutine triggered.");

        GetComponent<RespawnController>().Respawn();
    }

    public void Respawn()
    {
        // Reset light logic
        inSunlight = false;
        sunlightTimer = 0f;
        StopBlinking();

        dead = false;
        anim.ResetTrigger("die");
        anim.Play("Idle");

        foreach (Behaviour component in components)
        {
            component.enabled = true;
            Debug.Log("Re-enabled component: " + component.GetType().Name);
        }

        if (playerMovement != null && !playerMovement.enabled)
        {
            playerMovement.enabled = true;
            Debug.Log("Re-enabled PlayerMovement manually.");
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
