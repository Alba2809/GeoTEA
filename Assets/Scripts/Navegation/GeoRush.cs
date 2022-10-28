using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoRush : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private RectTransform avatar;
    [SerializeField] private RectTransform iconRestart;
    [SerializeField] private RectTransform title;
    [SerializeField] private GameObject board;
    [SerializeField] private RectTransform boxDialog;

    //audio
    [SerializeField] private AudioClip avatarSound;
    [SerializeField] private AudioSource audioSource;

    //variables de guardar informacion
    private string coinsPrefs = "Monedas";

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        LeanTween.moveX(avatar, -169f, 1.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack).setOnStart(audioAvatar).setOnComplete(alphaDialog);
        LeanTween.rotate(iconRestart, 360f, 0.5f).setDelay(0.5f);
        LeanTween.scale(title, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setDelay(0.3f).setOnComplete(titleScale);
        LeanTween.alphaCanvas(board.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(0.5f).setOnComplete(boardActive);   
    }

    private void audioAvatar()
    {
        audioSource.PlayOneShot(avatarSound);
    }

    private void titleScale()
    {
        LeanTween.scale(title, new Vector3(1f, 1f, 1f), 0.5f);
    }

    private void boardActive()
    {
        board.GetComponent<CanvasGroup>().interactable = true;
    }

    private void alphaDialog()
    {
        LeanTween.alpha(boxDialog, 1f, 1f);
    }

    public void Ajustes()
    {
        SceneManager.LoadScene("MenuAjustes");
    }

    public void Juegos()
    {
        SceneManager.LoadScene("MenuJuegos");
    }


    private void LoadData()
    {
        coinText.SetText("" + PlayerPrefs.GetInt(coinsPrefs, 0));
    }

}
