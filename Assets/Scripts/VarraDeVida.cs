using UnityEngine;
using UnityEngine.UI;

public class VarraDeVida : MonoBehaviour
{
    public Image healthBarImage; // Referencia a la imagen de la barra de vida
    public Wall wall; // Referencia al script Wall del objeto que queremos seguir

    private void Start()
    {
        // Verificamos si se proporcionó la referencia a la imagen y el script Wall
        if (healthBarImage == null)
        {
            Debug.LogError("HealthBar: Image reference is missing!");
        }

        if (wall == null)
        {
            Debug.LogError("HealthBar: Wall script reference is missing!");
        }
    }

    private void Update()
    {
        // Actualizamos el llenado de la barra de vida con la salud actual del objeto Wall
        if (healthBarImage != null && wall != null)
        {
            float fillAmount = (float)wall.health / 100f; // Calculamos el llenado como un valor entre 0 y 1
            healthBarImage.fillAmount = fillAmount;
        }
    }
}
