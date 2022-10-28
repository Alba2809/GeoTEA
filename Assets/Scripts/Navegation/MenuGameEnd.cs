using UnityEngine;
using UnityEngine.SceneManagement;
using System;

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
        currentCoins = PlayerPrefs.GetInt(coinsPrefs, 0);
        PlayerPrefs.SetInt(coinsPrefs, currentCoins + 10);
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
