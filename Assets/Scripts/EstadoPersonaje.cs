//Santiago Abraham Rios Palacios
using System;
using UnityEngine;

public class EstadoPersonaje : MonoBehaviour
{
    public bool estaEnPiso {get; private set;} = false;
    void Start()
    {
        print("Inicia estado personaje");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el personaje colisiona con el suelo
        estaEnPiso = true;
        print(estaEnPiso);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        estaEnPiso = false;
        print(estaEnPiso);
    }

}
