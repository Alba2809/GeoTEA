using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuGameEnd : MonoBehaviour
{
    //variable de cantidad de monedas
    private string coinsPrefs = "Monedas";
    private int currentCoins;

    //objeto de animación
    [SerializeField] private RectTransform menuEnd;
    [SerializeField] private GameObject menuGameEnd;

    

    public void PlusCoins()
    {
        int pc = 10;
        Scene sceneCurrent = SceneManager.GetActiveScene();
        if (sceneCurrent.name.Equals("GeoRush A")) pc = 10;  //coins to normal lvl
        if (sceneCurrent.name.Equals("GeoRush B")) pc = 20;  //coins to hard lvl
        currentCoins = PlayerPrefs.GetInt(coinsPrefs, 0);
        PlayerPrefs.SetInt(coinsPrefs, currentCoins + pc);
    }


    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReloadEndPlay()
    {
        LeanTween.scale(menuEnd, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(Reload);
    }

    private void Menu()
    {
        SceneManager.LoadScene("MenuJuegos");
    }

    public void MenuEndPlay()
    {
        LeanTween.scale(menuEnd, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(Menu);
    }

}
