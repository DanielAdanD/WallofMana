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
        // Aquí puedes agregar el código para realizar acciones cuando el objeto muere.
        // Por ejemplo, reproducir una animación, desactivar el objeto, etc.
        Destroy(gameObject);
    }
}
