using UnityEngine;

public class EnemigoAccionCompleto : MonoBehaviour
{
    
    [Header("Configuración del Volteo")]
    public float intervaloFlip = 0.1f; 
    private float cronometro = 0f;
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        cronometro = intervaloFlip;
    }

    void Update()
    {
      
        cronometro -= Time.deltaTime;

      
        if (cronometro <= 0f)
        {
            
            spriteRenderer.flipX = !spriteRenderer.flipX;

            cronometro = intervaloFlip;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(collision.gameObject, 0.2f);
            
            Debug.Log("¡Enemigo tocó a Mario!");
        }
    }
}