using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAjustes : MonoBehaviour
{
    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private RectTransform menuObjetosAjustes;
    [SerializeField] private GameObject Canvas;
    PauseGameRunner pause;

    //slider UI
    public Slider sliderMusica;
    public Slider sliderEfecto;

    //ajueste de musica y efectos
    public string musicaPrefs { get { return "Musica"; } }
    public string efectoPrefs { get { return "Efecto"; } }
    //public int currentCoins { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<PauseGameRunner>();
        float musica = PlayerPrefs.GetFloat(musicaPrefs, 0f);
        float efecto = PlayerPrefs.GetFloat(efectoPrefs, 0f);
        
        sliderMusica.value = musica;
        sliderEfecto.value = efecto;

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void Ajustes()
    {
        menuAjustes.SetActive(true);
        LeanTween.scale(menuObjetosAjustes, new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutBack);

        Canvas.SetActive(false);
        Invoke("PauseGame", 0.6f);
    }

    void PauseGame()
    {
         pause.ChangeGameRunningState();
    }

    public void AjustesDisabled()
    {
        menuAjustes.SetActive(false);
        Canvas.SetActive(true);
        pause.ChangeGameRunningState();


    }

    public void SetMusicaPref()
    {
        PlayerPrefs.SetFloat(musicaPrefs, sliderMusica.value);
    }

    public void SetEfectoPref()
    {
        PlayerPrefs.SetFloat(efectoPrefs, sliderEfecto.value);
    }
}
