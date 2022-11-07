using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAjustes : MonoBehaviour
{

    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private RectTransform menuObjetosAjustes;

    public void Regresar()
    {
        LeanTween.scale(menuObjetosAjustes, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(Ocultar);
    }

    private void Ocultar()
    {
        menuAjustes.SetActive(false);
    }
}
