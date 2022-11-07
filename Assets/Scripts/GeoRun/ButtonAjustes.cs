using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonAjustes : MonoBehaviour
{
    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private RectTransform menuObjetosAjustes;
    [SerializeField] private GameObject Canvas;
    PauseGameRunner pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<PauseGameRunner>();
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
        //var t = Task.Run(async delegate
        //{
        //    await Task.Delay(1000);
        //});
        //t.Wait();
        //Debug.Log("timento");

        
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
}
