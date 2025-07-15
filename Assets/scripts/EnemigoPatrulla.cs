using UnityEngine;

public class EnemigoPatrulla : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Vector3 destino;

    void Start()
    {
        destino = puntoB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            destino = destino == puntoA.position ? puntoB.position : puntoA.position;
            Girar();
        }
    }

    void Girar()
    {
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    
       void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Colisión con: " + collision.name);

    if (collision.CompareTag("Player"))
    {
        VidaJugador vida = collision.GetComponent<VidaJugador>();
        if (vida != null)
        {
            Debug.Log("Jugador detectado, perdiendo vida");
            vida.PerderVida();
        }
        else
        {
            Debug.Log("No se encontró el script VidaJugador");
        }
    }
}



}
