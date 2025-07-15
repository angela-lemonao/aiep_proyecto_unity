using UnityEngine;

public class Llave : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCounter contador = FindObjectOfType<KeyCounter>();
            if (contador != null)
            {
                contador.AgregarLlave();
            }

            Destroy(gameObject); // Destruye la llave al recogerla
        }
    }
}
