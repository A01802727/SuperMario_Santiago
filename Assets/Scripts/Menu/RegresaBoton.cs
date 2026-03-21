using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class regresa : MonoBehaviour
{
    private UIDocument menu;
    private Button regresar;
    private void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        regresar = root.Q<Button>("regresar");
        if (regresar == null)
{
    Debug.LogError("No se encontró el botón");
}
else
{
    Debug.Log("Botón encontrado");
}

        //Callback
        regresar.clicked += CerrarEscena;
    }
    void OnDisable()
    {
        regresar.clicked -= CerrarEscena;
    }

    void CerrarEscena()
    {
        SceneManager.LoadScene("Menu");
    }
    
}