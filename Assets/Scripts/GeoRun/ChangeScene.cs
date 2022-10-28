using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //objeto que mostrar� las monedas
    [SerializeField] private TextMeshProUGUI coinText;

    //variable de guardar informacion
    private string coinsPrefs = "Monedas";

    private void Awake()
    {
        LoadData();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Debug.Log("siguiente");
    }

    public void SceneMenuJuegos()
    {
        SceneManager.LoadScene("MenuJuegos");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //m�todo que carga la cantidad de monedas, este valor est� guardado en memoria, 
    //por lo que no importa si se sale de la aplicaci�n
    private void LoadData()
    {
        coinText.SetText("" + PlayerPrefs.GetInt(coinsPrefs, 0));

    }
}
