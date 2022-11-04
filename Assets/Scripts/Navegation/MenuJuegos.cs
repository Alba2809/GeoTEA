using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJuegos : MonoBehaviour
{
    //objeto que mostrará las monedas
    [SerializeField] private TextMeshProUGUI coinText;

    //objetos que tendrán animaciones
    [SerializeField] private RectTransform logo;
    [SerializeField] private RectTransform btnGame1;
    [SerializeField] private RectTransform btnGame2;
    [SerializeField] private RectTransform btnGame3;
    [SerializeField] private RectTransform btnRetrun;
    [SerializeField] private RectTransform btnAjuste;

    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private RectTransform menuObjetosAjustes;


    //variable de guardar informacion
    private string coinsPrefs = "Monedas";

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        LeanTween.moveX(logo, 0f, 1f).setDelay(0.2f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveX(btnGame1, 0f, 1f).setDelay(0.2f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveX(btnGame2, 0f, 1f).setDelay(0.2f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveX(btnGame3, 0f, 1f).setDelay(0.2f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.alpha(btnRetrun, 1f, 2f).setDelay(0.2f);
        LeanTween.rotate(btnRetrun, 360f, 1f).setDelay(0.2f);
        LeanTween.alpha(btnAjuste, 1f, 2f).setDelay(0.2f);
        LeanTween.rotate(btnAjuste, 360f, 1f).setDelay(0.2f);
    }

    public void GeoRun()
    {

        LeanTween.moveY(logo, 950f, 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.alpha(btnGame1, 0f, 1f).setDelay(0.2f);
        LeanTween.alpha(btnGame2, 0f, 1f).setDelay(0.2f);
        LeanTween.alpha(btnGame3, 0f, 1f).setDelay(0.2f).setOnComplete(irGeoRun);
    }
    
    private void irGeoRun()
    {
        SceneManager.LoadScene("runner_720p");
    }

    public void Ajustes()
    {
        menuAjustes.SetActive(true);
        LeanTween.scale(menuObjetosAjustes, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    }

    public void Principal()
    {
        LeanTween.moveY(logo, 950f, 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.alpha(btnGame1, 0f, 1f).setDelay(0.2f);
        LeanTween.alpha(btnGame2, 0f, 1f).setDelay(0.2f);
        LeanTween.alpha(btnGame3, 0f, 1f).setDelay(0.2f);
        LeanTween.alpha(btnRetrun, 0f, 1.5f).setDelay(0.2f);
        LeanTween.rotate(btnRetrun, 360f, 1f).setDelay(0.2f);
        LeanTween.alpha(btnAjuste, 0f, 1.5f).setDelay(0.2f).setOnComplete(irPrincipal);
        LeanTween.rotate(btnAjuste, 360f, 1f).setDelay(0.2f);
    }

    private void irPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    //método que carga la cantidad de monedas, este valor está guardado en memoria, 
    //por lo que no importa si se sale de la aplicación
    private void LoadData()
    {
        coinText.SetText("" + PlayerPrefs.GetInt(coinsPrefs, 0));

    }
}
