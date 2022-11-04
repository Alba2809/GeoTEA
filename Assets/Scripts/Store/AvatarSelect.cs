using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int skin_seleccionado;
    public Avatar[] avatares;

    public Button botonComprar;

    public TextMeshProUGUI textoMonedas;

    private void Awake()
    {
        skin_seleccionado = PlayerPrefs.GetInt("AvatarSeleccionado", 0);
        
        foreach (GameObject avatar in skins)
            avatar.SetActive(false);

        skins[skin_seleccionado].SetActive(true);

        foreach(Avatar a in avatares)
        {
            if (a.precio == 0)
                a.desbloqueado = true;
            else
            {
                a.desbloqueado = PlayerPrefs.GetInt(a.nombre, 0) == 0 ? false : true; //0 bloqueado, 1 desbloqueado
            }
        }

        Disponible();
    }

    public void SiguienteAvatar()
    {
        skins[skin_seleccionado].SetActive(false);
        skin_seleccionado++;
        
        if (skin_seleccionado == skins.Length) skin_seleccionado = 0;

        skins[skin_seleccionado].SetActive(true);
        
        if(avatares[skin_seleccionado].desbloqueado)
            PlayerPrefs.SetInt("AvatarSeleccionado", skin_seleccionado);

        Disponible();
    }

    public void AnteriorAvatar()
    {
        skins[skin_seleccionado].SetActive(false);
        skin_seleccionado--;

        if (skin_seleccionado == -1) skin_seleccionado = skins.Length - 1;

        skins[skin_seleccionado].SetActive(true);

        if (avatares[skin_seleccionado].desbloqueado)
            PlayerPrefs.SetInt("AvatarSeleccionado", skin_seleccionado);

        Disponible();
    }

    public void Disponible() //verificar si el jugador ya compró un avatar ó si puede comprarlo según las monedas que tenga
    {
        textoMonedas.text = "" + PlayerPrefs.GetInt("Monedas", 0);
        if (avatares[skin_seleccionado].desbloqueado == true)
            botonComprar.gameObject.SetActive(false);
        else
        {
            botonComprar.GetComponentInChildren<TextMeshProUGUI>().text = "Precio" + avatares[skin_seleccionado].precio;

            if (PlayerPrefs.GetInt("Monedas", 0) < avatares[skin_seleccionado].precio)
            {
                botonComprar.gameObject.SetActive(true);
                botonComprar.interactable = false;
            }
            else
            {
                botonComprar.gameObject.SetActive(true);
                botonComprar.interactable = true;
            }
        }
    }

    public void Comprar()
    {
        int monedas = PlayerPrefs.GetInt("Monedas", 0);
        int precio_avatar = avatares[skin_seleccionado].precio;

        PlayerPrefs.SetInt("Monedas", monedas - precio_avatar);
        PlayerPrefs.SetInt(avatares[skin_seleccionado].nombre, 1); // comprado/desbloquedo
        PlayerPrefs.SetInt("AvatarSeleccionado", skin_seleccionado);

        avatares[skin_seleccionado].desbloqueado = true;

        Disponible();
    }
}
