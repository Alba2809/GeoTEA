using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFiguras : MonoBehaviour
{
    private int botones_presionados;
    private string fecha;
    [SerializeField] private GameObject menu_figuras;
    [SerializeField] private RectTransform menu_objetos_figuras;

    [SerializeField] private Button boton_continuar;

    // Start is called before the first frame update
    void Start()
    {
        fecha = System.DateTime.Now.ToString("MM/dd/yyyy");
        BotonContinuar();
    }

    public void EscucharFigura()
    {
        botones_presionados = PlayerPrefs.GetInt("figuras_escuchadas", 0);
        botones_presionados += 1;
        PlayerPrefs.SetInt("figuras_escuchadas", botones_presionados);

        BotonContinuar();
    }

    private void BotonContinuar()
    {
        botones_presionados = PlayerPrefs.GetInt("figuras_escuchadas", 0);

        if (botones_presionados == 0)
            boton_continuar.interactable = false;
        else
        {
            if(fecha.Equals(PlayerPrefs.GetString("fecha", fecha)))
                boton_continuar.interactable = true;
            else
            {
                PlayerPrefs.SetInt("figuras_escuchadas", 0);
                boton_continuar.interactable = false;
            }
        }
            
    }

    public void Continuar()
    {
        LeanTween.scale(menu_objetos_figuras, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack)
            .setOnComplete(IrMenuJuegos);
    }

    private void IrMenuJuegos()
    {
        menu_figuras.SetActive(false);
        SceneManager.LoadScene("MenuJuegos");
    }
}
