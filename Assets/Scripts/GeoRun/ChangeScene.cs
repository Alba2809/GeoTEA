using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //objeto que mostrará las monedas
    [SerializeField] private TextMeshProUGUI coinText;

    //cambiar escena
    [SerializeField] private RectTransform menuEnd;

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

    public void SceneRunnerLevel2()
    {
        SceneManager.LoadScene("runner_level2");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //método que carga la cantidad de monedas, este valor está guardado en memoria, 
    //por lo que no importa si se sale de la aplicación
    private void LoadData()
    {
        coinText.SetText("" + PlayerPrefs.GetInt(coinsPrefs, 0));

    }

    private void Menu()
    {
        SceneManager.LoadScene("MenuJuegos");
    }

    public void MenuEndPlay()
    {
        Time.timeScale = 1;
        //Menu();
        Invoke("Menu", 0.1f);
       
    }

    private void animacion()
    {
        LeanTween.scale(menuEnd, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    }
}
