using UnityEngine;

public class SonidoAlAparecerSprite : MonoBehaviour
{
    public AudioClip sonido;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = sonido;
    }

    private void OnBecameVisible()
    {
        if (spriteRenderer.isVisible && sonido != null)
        {
            audioSource.Play();
        }
    }
}
