using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
{
      float  movimiento  = Input.GetAxisRaw("Horizontal");
       rb.velocity =  new  Vector2(movimiento *  velocidad,  rb.velocity.y);

       // Actualiza  el  parámetro de  velocidad  para la  animación
      animator.SetFloat("Velocidad",  Mathf.Abs(movimiento));

      //  Voltear sprite  según  dirección
      if  (movimiento !=  0)
      {
             transform.localScale  =  new Vector3(Mathf.Sign(movimiento),  1,  1);
      }
}
}