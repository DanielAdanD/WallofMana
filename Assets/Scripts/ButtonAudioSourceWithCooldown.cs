using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAudioSourceWithCooldown : MonoBehaviour
{
    public AudioSource audioSource;
    public float cooldownTime = 0.2f; // Tiempo mínimo entre repeticiones
    public bool allowRepeating = true; // Permitir la repetición mientras se mantiene presionado el botón

    [SerializeField]
    private KeyCode selectedButton;

    private bool isButtonDown = false;
    private float lastPlayTime;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ResetCooldown();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (Input.GetKeyDown(selectedButton) && Time.time - lastPlayTime >= cooldownTime)
        {
            isButtonDown = true;
            PlayAudio();
            lastPlayTime = Time.time;
        }

        if (Input.GetKeyUp(selectedButton))
        {
            isButtonDown = false;
        }

        if (allowRepeating && isButtonDown && Time.time - lastPlayTime >= cooldownTime)
        {
            PlayAudio();
            lastPlayTime = Time.time;
        }
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Resetea el estado al iniciar el nivel o cambiar de escena
        ResetCooldown();
    }

    private void ResetCooldown()
    {
        lastPlayTime = 0f;
        isButtonDown = false;
    }
}
