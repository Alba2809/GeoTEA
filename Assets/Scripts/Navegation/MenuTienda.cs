using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTienda : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private string coinsPrefs = "Monedas";

    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private RectTransform menuObjetosAjustes;

    private void Awake()
    {
        LoadData();
    }

    public void Ajustes()
    {
        menuAjustes.SetActive(true);
        LeanTween.scale(menuObjetosAjustes, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    }

    public void Principal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void LoadData()
    {
        coinText.SetText("" + PlayerPrefs.GetInt(coinsPrefs, 0));

    }
}
