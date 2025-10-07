using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    // El Transform de la bola que queremos seguir
    public Transform Objetivo;

    // Distancia fija que queremos mantener con respecto a la bola
    public Vector3 Offset = new Vector3(0f, 2f, -5f);

    // Suavidad del seguimiento. Un valor más alto significa seguimiento más rápido.
    public float Suavidad = 5f;

    void LateUpdate()
    {
        // 1. Verificamos que tengamos un objetivo asignado
        if (Objetivo == null)
        {
            Debug.LogError("El script SeguimientoCamara necesita un 'Objetivo' (la bola) asignado en el Inspector.");
            return;
        }

        // 2. Calculamos la posición deseada
        // Es la posición de la bola más el offset (detrás y arriba)
        Vector3 posicionDeseada = Objetivo.position + Offset;

        // 3. Aplicamos un movimiento suave (Lerp) para evitar un seguimiento brusco
        // Esto crea el efecto de "cámara flotante"
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, Suavidad * Time.deltaTime);

        // 4. Aplicamos la nueva posición a la cámara
        transform.position = posicionSuavizada;

        // 5. Opcional: Aseguramos que la cámara siempre mire hacia adelante (hacia la bola)
        // Esto mantiene la cámara derecha y enfocada
        // Si no quieres que mire directamente a la bola (por ejemplo, si quieres que mire siempre al frente), omite esta línea:
        // transform.LookAt(Objetivo);
    }
}