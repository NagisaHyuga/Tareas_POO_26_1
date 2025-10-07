using UnityEngine;

public class ControlBola : MonoBehaviour
{
    // NO necesitamos CamaraPrincipal aquí si el script de seguimiento se encarga
    // public Transform CamaraPrincipal; 

    public Rigidbody rb;
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;
    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de que el Rigidbody está asignado
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Expresión: mientras que haSidoLanzada sea falso puedes disparar.
        if (haSidoLanzada == false)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
    }

    void Apuntar()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }

    void Lanzar()
    {
        haSidoLanzada = true;
        // Aplicamos la fuerza
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

        // ¡IMPORTANTE! Eliminamos la línea que hacía la cámara hija:
        // if(CamaraPrincipal !=null)
        // {
        //     CamaraPrincipal.SetParent(transform);
        // }
    }
} // Bienvenido a la entrada al infierno
