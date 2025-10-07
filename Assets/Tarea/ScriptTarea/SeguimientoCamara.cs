using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    // El Transform de la bola que queremos seguir
    public Transform Objetivo;

    // Distancia fija que queremos mantener con respecto a la bola
    public Vector3 Offset = new Vector3(0f, 2f, -5f);

    // Suavidad del seguimiento. Un valor m�s alto significa seguimiento m�s r�pido.
    public float Suavidad = 5f;

    void LateUpdate()
    {
        // 1. Verificamos que tengamos un objetivo asignado
        if (Objetivo == null)
        {
            Debug.LogError("El script SeguimientoCamara necesita un 'Objetivo' (la bola) asignado en el Inspector.");
            return;
        }

        // 2. Calculamos la posici�n deseada
        // Es la posici�n de la bola m�s el offset (detr�s y arriba)
        Vector3 posicionDeseada = Objetivo.position + Offset;

        // 3. Aplicamos un movimiento suave (Lerp) para evitar un seguimiento brusco
        // Esto crea el efecto de "c�mara flotante"
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, Suavidad * Time.deltaTime);

        // 4. Aplicamos la nueva posici�n a la c�mara
        transform.position = posicionSuavizada;

        // 5. Opcional: Aseguramos que la c�mara siempre mire hacia adelante (hacia la bola)
        // Esto mantiene la c�mara derecha y enfocada
        // Si no quieres que mire directamente a la bola (por ejemplo, si quieres que mire siempre al frente), omite esta l�nea:
        // transform.LookAt(Objetivo);
    }
}