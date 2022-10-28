using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOut : MonoBehaviour
{
    [SerializeField] private GameObject menGameOut;
    [SerializeField] private RectTransform menuOut;
    [SerializeField] private RectTransform menuOutFondo;

    [SerializeField] private RectTransform avatar;
    [SerializeField] private RectTransform iconRestart;
    [SerializeField] private RectTransform title;
    [SerializeField] private GameObject board;
    [SerializeField] private RectTransform boxDialog;

    [SerializeField] private TextMeshProUGUI restartText;
    [SerializeField] private TextMeshProUGUI popText;

    public void showMenu()
    {
        menGameOut.SetActive(true);
        LeanTween.scale(menuOut, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    }

    private void Yes()
    {
        SceneManager.LoadScene("MenuJuegos");
    }

    public void No()
    {
        LeanTween.scale(menuOut, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(returnGame);
    }

    private void returnGame()
    {
        menGameOut.SetActive(false);
    }

    public void menuOutPlay()
    {
        LeanTween.scale(menuOut, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(outGame);
    }


    private void outGame()
    {
        LeanTween.alpha(boxDialog, 0f, 1f).setOnComplete(moverAvatar);
        popText.SetText("");
        restartText.SetText("");
        LeanTween.rotate(iconRestart, 360f, 0.5f).setDelay(0.5f);
        LeanTween.alpha(iconRestart, 0f, 1f).setDelay(0.5f);
        LeanTween.scale(title, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setDelay(0.3f).setOnComplete(titleScale);
        board.GetComponent<CanvasGroup>().interactable = false;
        LeanTween.alphaCanvas(board.GetComponent<CanvasGroup>(), 0f, 1f).setDelay(0.5f);
    }

    private void moverAvatar()
    {
        LeanTween.moveX(avatar, 533f, 1f).setDelay(0.5f).setEase(LeanTweenType.easeInBack).setOnComplete(Yes);
    }

    private void titleScale()
    {
        LeanTween.scale(title, new Vector3(0f, 0f, 0f), 0.5f);
    }
    
}
