using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    public int vidasMaximas = 3;
    public int vidasActuales;

    public TMP_Text textoVidas;
    public GameObject textoGameOver;
    public GameObject botonReiniciar;

    public AudioClip sonidoDaño;
    public AudioSource audioDaño; // Puedes usar este si quieres un canal separado

    void Start()
    {
        vidasActuales = vidasMaximas;
        ActualizarTexto();

        if (textoGameOver != null) textoGameOver.SetActive(false);
        if (botonReiniciar != null) botonReiniciar.SetActive(false);
    }

    public void PerderVida()
    {
        vidasActuales--;

        // Reproducir sonido de daño
        if (sonidoDaño != null && audioDaño != null)
        {
            audioDaño.PlayOneShot(sonidoDaño);
        }

        if (vidasActuales <= 0)
        {
            vidasActuales = 0;
            ActualizarTexto();

            if (textoGameOver != null) textoGameOver.SetActive(true);
            if (botonReiniciar != null) botonReiniciar.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidasActuales;
        }
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
