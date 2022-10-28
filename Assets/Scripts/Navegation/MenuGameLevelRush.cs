using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameLevelRush : MonoBehaviour
{
    [SerializeField] private GameObject menGameLvl;
    [SerializeField] private RectTransform menuLvl;
    //[SerializeField] private RectTransform menuLvlFondo;


    public void ShowMenu()
    {
        menGameLvl.SetActive(true);
        LeanTween.scale(menuLvl, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    }

    public void NormalLvl()
    {
        LeanTween.scale(menuLvl, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(GoGeoRushA);
        
    }

    public void HardLvl()
    {
        LeanTween.scale(menuLvl, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(GoGeoRushB);
    }

    private void GoGeoRushA()
    {
        menGameLvl.SetActive(false);
        SceneManager.LoadScene("GeoRush A");
    }

    private void GoGeoRushB()
    {
        menGameLvl.SetActive(false);
        SceneManager.LoadScene("GeoRush B");
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
