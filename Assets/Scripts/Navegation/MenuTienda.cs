using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTienda : MonoBehaviour
{
    public void Ajustes()
    {
        SceneManager.LoadScene("MenuAjustes");
    }

    public void Principal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
