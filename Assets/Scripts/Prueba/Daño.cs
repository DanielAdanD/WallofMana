using UnityEngine;

public class Daño : MonoBehaviour
{
    public int cantidadDanio = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vida vida = other.GetComponent<Vida>();

        if (vida != null)
        {
            vida.RecibirDanio(cantidadDanio);
            // Aquí puedes agregar código adicional, como reproducir un sonido de impacto, mostrar efectos visuales, etc.
        }
    }
}
