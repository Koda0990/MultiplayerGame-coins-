using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
public class Movement : MonoBehaviour
{
    float xmov;
    float ymov; 
    Rigidbody2D rb;
    public int movSpeed;
    Animator animator;
    Vector2  mov;
    private int Puntos; 
    private enum Estado
    {
        Idle, IdleIzq, IdleDer, IdleBack,
        Mov, MovIzq, MovDer, MovBack,
    }
    private Estado estado;
    PhotonView m_PV; 

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        estado = Estado.Idle;
        m_PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PV.IsMine)
        {
            xmov = Input.GetAxis("Horizontal");
            ymov = Input.GetAxis("Vertical");
            mov = new Vector2(xmov, ymov).normalized;
        }
    
    }
    
    private void FixedUpdate()
    {
        if (m_PV.IsMine)
        {
            //rb.velocity = new Vector2(xMov, ymov).normalized * movSpeed;
            rb.MovePosition(rb.position + mov * movSpeed * Time.fixedDeltaTime);
            if (ymov != 0)
            {
                if (ymov > 0)
                {
                    CambiarAnimacion(Estado.MovBack);
                }
                if (ymov < 0)
                {
                    CambiarAnimacion(Estado.Mov);
                }
            }
            else if (xmov != 0)
            {
                if (xmov > 0)
                {
                    CambiarAnimacion(Estado.MovDer);
                }
                if (xmov < 0)
                {
                    CambiarAnimacion(Estado.MovIzq);
                }
            }
            else if (xmov == 0 && ymov == 0)
            {
                if (estado == Estado.MovIzq)
                {
                    CambiarAnimacion(Estado.IdleIzq);
                }
                if (estado == Estado.MovDer)
                {
                    CambiarAnimacion(Estado.IdleDer);
                }
                if (estado == Estado.MovBack)
                {
                    CambiarAnimacion(Estado.IdleBack);
                }
                if (estado == Estado.Mov)
                {
                    CambiarAnimacion(Estado.Idle);
                }
            }
        }
    }
    void CambiarAnimacion(Estado nuevoEstado)
    {
        if (estado == nuevoEstado) 
        {
            return; 
        }
        estado = nuevoEstado;
        animator.Play(estado.ToString());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hamburguesa "))
        {
            Destroy(collision.gameObject);
            Puntos++;
            print("Puntos: " + Puntos); 
        }
    }
}
