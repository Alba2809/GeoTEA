using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoRush : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    //[SerializeField] private RectTransform avatar;
    [SerializeField] private RectTransform iconRestart;
    [SerializeField] private RectTransform title;
    [SerializeField] private GameObject board;
    [SerializeField] private RectTransform boxDialog;

    //audio
    [SerializeField] private AudioClip avatarSound;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private RectTransform menuObjetosAjustes;

    //obtener avatar seleccionado
    GameObject avatar;
    public GameObject[] avatarPrefabs;
    public GameObject contenedor;
    public Vector2 posicion;
    //new Vector2(1000, -574)
    int avatarIndex;

    //variables de guardar informacion
    private string coinsPrefs = "Monedas";

    private void Awake()
    {
        LoadData();
        avatarIndex = PlayerPrefs.GetInt("AvatarSeleccionado", 0);
        avatar = Instantiate(avatarPrefabs[avatarIndex], posicion, Quaternion.identity, contenedor.transform);
        avatar.GetComponent<RectTransform>().sizeDelta = new Vector2(338, 338);
    }

    private void Start()
    {
        //evitar rotacion que el juego se pueda jugar en horizontal
        Screen.orientation = ScreenOrientation.Portrait;
        LeanTween.moveX(avatar.GetComponent<RectTransform>(), -169f, 1.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack).setOnStart(audioAvatar).setOnComplete(alphaDialog);
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
        menuAjustes.SetActive(true);
        LeanTween.scale(menuObjetosAjustes, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
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
