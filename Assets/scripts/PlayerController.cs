using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    public float longitudRayCast = 0.1f;
    public LayerMask capaSuelo;

    private bool enSuelo;
    private Rigidbody2D rb;

    public AudioClip audioClip;
    public AudioSource audioSource;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float velocidadX = inputX * velocidad;

        // Movimiento horizontal
        Vector3 posicion = transform.position;
        transform.position = new Vector3(posicion.x + velocidadX * Time.deltaTime, posicion.y, posicion.z);

        // Animación
        animator.SetFloat("movement", Mathf.Abs(velocidadX));

        // Flip del sprite
        if (inputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (inputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Detección de suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRayCast, capaSuelo);
        enSuelo = hit.collider != null;
        animator.SetBool("ensuelo", enSuelo);

        // Salto
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            if (audioClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRayCast);
    }
}
