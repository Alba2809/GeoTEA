using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameLevelRun : MonoBehaviour
{
    [SerializeField] private GameObject menGameLvl;
    [SerializeField] private RectTransform menuLvl;

    public void ShowMenu()
    {
        menGameLvl.SetActive(true);
        LeanTween.scale(menuLvl, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    }

    public void NormalLvl()
    {
        LeanTween.scale(menuLvl, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(GoRunNormal);

    }

    public void HardLvl()
    {
        LeanTween.scale(menuLvl, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(GoRunHard);
    }

    private void GoRunNormal()
    {
        menGameLvl.SetActive(false);
        SceneManager.LoadScene("runner_720p");
    }

    private void GoRunHard()
    {
        menGameLvl.SetActive(false);
        SceneManager.LoadScene("runner_level2");
    }

    public void OutGameLevel()
    {
        LeanTween.scale(menuLvl, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(SetMenuFalse);
    }

    private void SetMenuFalse()
    {
        menGameLvl.SetActive(false);
    }
}
