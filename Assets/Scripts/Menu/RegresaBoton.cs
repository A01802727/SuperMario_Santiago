//Santiago Abraham Rios Palacios
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
        //Obtener el componente UIDocument del objeto al que está asignado este script
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        regresar = root.Q<Button>("regresar");

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