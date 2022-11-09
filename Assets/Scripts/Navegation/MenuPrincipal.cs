using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    [SerializeField] private RectTransform logo;
    [SerializeField] private RectTransform btnJugar;
    [SerializeField] private RectTransform btnTienda;
    [SerializeField] private RectTransform btnAjustes;
    [SerializeField] private GameObject monedas;
    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private RectTransform menuObjetosAjustes;
    //[SerializeField] private RectTransform menuAjustesFondo;

    [SerializeField] private GameObject menu_figuras;
    [SerializeField] private RectTransform menu_objetos_figuras;

    //variable de animacion
    private float delayLeft = 0.5f;

    //variables de guardar informacion
    private string coinsPrefs = "Monedas";
    private string _sceneName = "";

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        //evitar rotacion que el juego se pueda jugar en horizontal
        Screen.orientation = ScreenOrientation.Portrait;
        LeanTween.moveY(logo, 257, 1.25f).setDelay(1f).setEase(LeanTweenType.easeOutBounce).setOnComplete(btnJTA);
        _sceneName = "";
    }
    //animaciones
    private void btnJTA()
    {
        LeanTween.alpha(btnJugar, 1f, 1f);
        LeanTween.alpha(btnTienda, 1f, 1f);
        LeanTween.scale(monedas, new Vector3(1f,1f,1f), 1f);
        LeanTween.alpha(btnAjustes, 1f, 2f);
        LeanTween.rotate(btnAjustes, 360f, 1f);
    }


    //funciones de cambio de escenas

    private void sceneChange()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Jugar()
    {
        /*string fecha = System.DateTime.Now.ToString("MM/dd/yyyy");
        if (PlayerPrefs.GetInt("figuras_escuchadas", 0) > 0 && fecha.Equals(PlayerPrefs.GetString("fecha", fecha)))
        {
            _sceneName = "MenuJuegos";
            LeanTween.moveX(logo, -900f, 1f).setDelay(delayLeft).setEase(LeanTweenType.easeInBack);
            LeanTween.moveX(btnJugar, -900f, 1f).setDelay(delayLeft).setEase(LeanTweenType.easeInBack);
            LeanTween.moveX(btnTienda, -900f, 1f).setDelay(delayLeft).setEase(LeanTweenType.easeInBack).setOnComplete(sceneChange);
        }
        else
        {*/
            menu_figuras.SetActive(true);
            LeanTween.scale(menu_objetos_figuras, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
        //}
        
    }


    public void Tienda()
    {
        _sceneName = "Tienda";
        LeanTween.moveX(logo, -900f, 1f).setDelay(delayLeft).setEase(LeanTweenType.easeInBack);
        LeanTween.moveX(btnJugar, -900f, 1f).setDelay(delayLeft).setEase(LeanTweenType.easeInBack);
        LeanTween.moveX(btnTienda, -900f, 1f).setDelay(delayLeft).setEase(LeanTweenType.easeInBack).setOnComplete(sceneChange);
    }

    public void Ajustes()
    {
        menuAjustes.SetActive(true);
        LeanTween.scale(menuObjetosAjustes, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    }


    private void LoadData() {
        coinText.SetText("" + PlayerPrefs.GetInt(coinsPrefs, 0));
        
    }
}
