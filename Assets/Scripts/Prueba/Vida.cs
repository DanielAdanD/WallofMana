using UnityEngine;

public class Vida : MonoBehaviour
{
    public int puntosDeVida = 100;

    public void RecibirDanio(int cantidadDanio)
    {
        puntosDeVida -= cantidadDanio;

        if (puntosDeVida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        // Aqu� puedes agregar el c�digo para realizar acciones cuando el objeto muere.
        // Por ejemplo, reproducir una animaci�n, desactivar el objeto, etc.
        Destroy(gameObject);
    }
}
