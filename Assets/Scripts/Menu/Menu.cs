using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private VisualElement root;

    private VisualElement menu;
    private VisualElement menuAyuda;
    private VisualElement menuCreditos;

    private Label creditosLabel;
    private VisualElement creditosContainer;

    public float scrollSpeed = 30f; // Velocidad más cinematográfica

    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        menu = root.Q<VisualElement>("Menu");
        menuAyuda = root.Q<VisualElement>("MenuAyuda");
        menuCreditos = root.Q<VisualElement>("MenuCreditos");

        Button jugar = root.Q<Button>("Jugar");
        Button ayuda = root.Q<Button>("Ayuda");
        Button creditos = root.Q<Button>("Creditos");

        Button closeAyuda = menuAyuda.Q<Button>("CloseBoton");
        Button closeCreditos = menuCreditos.Q<Button>("CloseBoton");

        creditosContainer = menuCreditos.Q<VisualElement>("CreditosContainer");
        creditosLabel = menuCreditos.Q<Label>("Creditos");

        // Para poder moverlo libremente
        creditosLabel.style.position = Position.Absolute;

        // BOTÓN JUGAR
        jugar.clicked += () => SceneManager.LoadScene("SampleScene");

        // BOTÓN AYUDA
        ayuda.clicked += () =>
        {
            menu.style.display = DisplayStyle.None;
            menuAyuda.style.display = DisplayStyle.Flex;
        };

        // BOTÓN CRÉDITOS
        creditos.clicked += () =>
        {
            menu.style.display = DisplayStyle.None;
            menuCreditos.style.display = DisplayStyle.Flex;

            // IMPORTANTE: iniciar abajo del contenedor (como créditos reales)
            creditosLabel.style.top = creditosContainer.resolvedStyle.height;
        };

        // CERRAR AYUDA
        closeAyuda.clicked += () =>
        {
            menuAyuda.style.display = DisplayStyle.None;
            menu.style.display = DisplayStyle.Flex;
        };

        // CERRAR CRÉDITOS
        closeCreditos.clicked += () =>
        {
            menuCreditos.style.display = DisplayStyle.None;
            menu.style.display = DisplayStyle.Flex;
        };

        // Ocultar menús secundarios al inicio
        menuAyuda.style.display = DisplayStyle.None;
        menuCreditos.style.display = DisplayStyle.None;
    }

    void Update()
    {
        if (menuCreditos != null && menuCreditos.style.display == DisplayStyle.Flex)
        {
            float currentTop = creditosLabel.resolvedStyle.top;

            // Movimiento hacia arriba
            currentTop -= scrollSpeed * Time.deltaTime;

            creditosLabel.style.top = currentTop;

            // Cuando todo el texto salió por arriba, reinicia abajo
            if (currentTop + creditosLabel.resolvedStyle.height < 0)
            {
                creditosLabel.style.top = creditosContainer.resolvedStyle.height;
            }
        }
    }
}