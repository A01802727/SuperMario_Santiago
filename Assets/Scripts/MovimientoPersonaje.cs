//Santiago Abraham Rios Palacios
using UnityEngine;
using UnityEngine.InputSystem;


public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover; //en las cuatro direcciones 
    [SerializeField]
    private InputAction accionSaltar; //para saltar con espacio

    private float velocidadX = 7f;
    private float velocidadY = 8f;
    private bool enSuelo = true; //para saber si el personaje esta en el suelo o no, para que no pueda saltar en el aire

    private Rigidbody2D rb; //Para saltar y caminar horizontal

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //hailitar el inputaction
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>(); //obtengo el rigidbody del objeto para modificar su velocidad
    }

    void OnEnable() //ESTO ES O=TRO METODO DE MONOBEHAVIOUR QUE SE EJECUTA CUANDO SE HABILITA EL OBJETO O EL SCRIPT, ES DECIR CUANDO SE ACTIVA EN LA ESCENA O SE HABILITA DESDE EL EDITOR
    {
        accionSaltar.Enable();//lo habilito y digo que queiro hace cuando lo habitilite, es decir que quiero que se ejecute el metodo saltar cuando se pulse el espacio
        accionSaltar.performed +=saltar; //le digo que cuando se habilita agrega esta funcion  al objeto 
    }

    void OnDisable()
    {
        accionSaltar.Disable();
        accionSaltar.performed -=saltar; //le digo que cuando se deshabilite quita esta funcion  al objeto tengo que implementar saltar ENSERIO
    }

    public void saltar (InputAction.CallbackContext context)
    {
        if (enSuelo)
        {
            rb.linearVelocityY = velocidadY; //le doy una velocidad en y para que salte
            enSuelo = false; //cuando salta ya no esta en el suelo
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            enSuelo = true;
        }
    // Update is called once per frame
    void Update()
    {
        //leer la entrada
        Vector2 movimiento = accionMover.ReadValue<Vector2>(); //lee el valor del inputaction y lo guarda en un vector2
        rb.linearVelocityX = velocidadX * movimiento.x;
        //transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento; //al inicio con lo (vecot2) se hizo un cast para que pudieses sumar un vector que tiene x y y y otro que tiene x y si no seria xy y con xyz y eso no se puede modifica la posicion del objeto con la entrada del usuario, multiplicado por la velocidad y el tiempo para que sea independiente de l
    }
}       