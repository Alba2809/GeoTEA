using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumen : MonoBehaviour
{

    public Slider volumenMusica;
    public Slider volumenEfectos;

    public GameObject[] musica;
    public GameObject[] efectos;

    // Start is called before the first frame update
    void Start()
    {
        musica = GameObject.FindGameObjectsWithTag("musica");
        efectos = GameObject.FindGameObjectsWithTag("efecto");

        volumenMusica.value = PlayerPrefs.GetFloat("volumenMusica", 0.3f);
        volumenEfectos.value = PlayerPrefs.GetFloat("volumenEfectos", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in musica)
            go.GetComponent<AudioSource>().volume = volumenMusica.value;
        
        foreach (GameObject go in efectos)
            go.GetComponent<AudioSource>().volume = volumenEfectos.value;
    }

    public void GuardarVolumenMusica()
    {
        PlayerPrefs.SetFloat("volumenMusica", volumenMusica.value);
    }
    public void GuardarVolumenEfecto()
    {
        PlayerPrefs.SetFloat("volumenEfectos", volumenEfectos.value);
    }
}
