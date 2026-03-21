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

    public float scrollSpeed = 50f; 
    private float currentMargin;

    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        menu = root.Q<VisualElement>("Menu");
        menuAyuda = root.Q<VisualElement>("MenuAyuda");
        menuCreditos = root.Q<VisualElement>("MenuCreditos");

        Button jugar = root.Q<Button>("Jugar");
        Button ayuda = root.Q<Button>("Ayuda");
        Button creditos = root.Q<Button>("Creditos");
        Button closeGame = root.Q<Button>("CloseGame");

        Button closeAyuda = menuAyuda.Q<Button>("CloseBoton");
        Button closeCreditos = menuCreditos.Q<Button>("CloseBoton");

        creditosContainer = menuCreditos.Q<VisualElement>("CreditosContainer");
        creditosLabel = menuCreditos.Q<Label>("Creditos");


        jugar.clicked += () => SceneManager.LoadScene("SampleScene");

        ayuda.clicked += () => {
            menu.style.display = DisplayStyle.None;
            menuAyuda.style.display = DisplayStyle.Flex;
        };

        creditos.clicked += () => {
            menu.style.display = DisplayStyle.None;
            menuCreditos.style.display = DisplayStyle.Flex;
            
        
            float alturaContenedor = creditosContainer.layout.height;
            if (alturaContenedor <= 0) alturaContenedor = Screen.height; 

            currentMargin = alturaContenedor;
            creditosLabel.style.marginTop = currentMargin;
        };

        if (closeGame != null) {
            closeGame.clicked += () => {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            };
        }

        closeAyuda.clicked += () => VolverAlMenu(menuAyuda);
        closeCreditos.clicked += () => VolverAlMenu(menuCreditos);

        menuAyuda.style.display = DisplayStyle.None;
        menuCreditos.style.display = DisplayStyle.None;
    }

    void VolverAlMenu(VisualElement ventanaActual)
    {
        ventanaActual.style.display = DisplayStyle.None;
        menu.style.display = DisplayStyle.Flex;
    }

    void Update()
    {
        if (menuCreditos != null && menuCreditos.resolvedStyle.display == DisplayStyle.Flex)
        {
            currentMargin -= scrollSpeed * Time.deltaTime;

            if (currentMargin < -creditosLabel.layout.height)
            {
                currentMargin = creditosContainer.layout.height;
            }

            creditosLabel.style.marginTop = currentMargin;
        }
    }
}