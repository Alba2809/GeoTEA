using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAjustes : MonoBehaviour
{

    /*public MenuPrincipal mp;*/

    private void Start()
    {
        /*mp = FindObjectOfType<MenuPrincipal>();*/
    }


    public void Regresar()
    {
        /*if (mp.activo.Equals(true))*/
        SceneManager.LoadScene("MenuPrincipal");
    }
}
