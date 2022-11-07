using UnityEngine;

public class PauseGameRunner : MonoBehaviour
{
    [SerializeField]
    private bool gameRunning = true;

    public GameObject button;

    //regresar
    [SerializeField] private GameObject menGameOut;
    [SerializeField] private RectTransform menuOut;

    // Start is called before the first frame update
    void Start()
    {
        //evitar rotacion que el juego se pueda jugar en horizontal
        Screen.orientation = ScreenOrientation.Portrait;

        button = GameObject.Find("IniciarJuego");
        //juego pausado al empezar el juego
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           ChangeGameRunningState();
        }

        //button.onClick.AddListener(() => disabledButton());

    }

    public void ChangeGameRunningState()
    {
        //gameRunning = !gameRunning;

        if (gameRunning)
        {
            //juego corriendo
            //Debug.Log("corriendo");
            Time.timeScale = 1;

            //reanudar audio
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.Play();
            }
        }
        else
        {
            //juego pausado
            //Debug.Log("pausado");
            Time.timeScale = 0;

            //pausar audio
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.Pause();
            }
        }
        gameRunning = !gameRunning;
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }

    public void DisabledButton()
    {
        button.gameObject.SetActive(false);
    }

    public void GameRunning()
    {
        gameRunning = false;
        Time.timeScale = 1;
    }


    //para salir de la aplicacion 
    public void showMenu()
    {
        menGameOut.SetActive(true);
        LeanTween.scale(menuOut, new Vector3(1, 1, 1), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutBack);
        Invoke("ChangeGameRunningState", 0.6f);
    }

    public void MenuDisabled()
    {
        menGameOut.SetActive(false);
        ChangeGameRunningState();
    }
}
