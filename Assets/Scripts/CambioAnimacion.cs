//Santiago Abraham Rios Palacios
using System;
using UnityEngine;

public class CambioAnimacion : MonoBehaviour



{
    private Animator animator; //referencia al componente de animacion del personaje

    private Rigidbody2D rb; //referencia al componente de fisica del personaje

    private SpriteRenderer sr; //referencia al componente de renderizado del personaje para cambiar la direccion del sprite
    private EstadoPersonaje estado;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocidad",MathF.Abs(rb.linearVelocityX));
        //Manejar FLIP x
        sr.flipX = rb.linearVelocityX < 0;

        //Manejar animacion de salto
        animator.SetBool("enPiso",estado.estaEnPiso);
        
        
    }
}
