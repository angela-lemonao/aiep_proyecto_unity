using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    public int llavesRecogidas = 0;
    public TMP_Text textoLlaves;

    public void AgregarLlave()
    {
        llavesRecogidas++;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        textoLlaves.text = "Llaves recogidas: " + llavesRecogidas;
    }
}