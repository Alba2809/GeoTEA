using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentanaCarga : MonoBehaviour
{

    [SerializeField] private RectTransform logo;

    void Start()
    {
        //evitar rotacion que el juego se pueda jugar en horizontal
        Screen.orientation = ScreenOrientation.Portrait;
        LeanTween.moveY(logo, 53, 1.5f).setDelay(1f).setEase(LeanTweenType.easeOutElastic).setOnComplete(logoAlpha);
    }

    private void logoAlpha()
    {
        LeanTween.alpha(logo, 0, 1.5f).setDelay(3f).setOnComplete(Principal);
    }

    private void Principal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
