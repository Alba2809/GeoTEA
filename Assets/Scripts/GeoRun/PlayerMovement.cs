using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;
using TMPro;
//[System.Serializable]
//public enum SIDE { Left,Mid,Right}

public class PlayerMovement : MonoBehaviour
{
    //publicos
    //public SIDE m_SIDE = SIDE.Mid;
    public float speed;
    public float speedMov;
    public GameObject highway;
    public GameObject[] formas;
    public SpriteRenderer[] formasSprite;
    public Sprite[] formasArr;
    public bool levelOne;
    public int intentos { get; set; } = 3;
    public int aciertos { get; set; } = 0;
    /*
    public AudioClip soundButton;
    public AudioSource soundPlayer; //cuando aparece el jugador por primera vez
    public AudioSource soundFinalGame; */

    public Image Image;

    public Transform start;
    public Transform end;

    //sonido cuando aparece jugador
    public AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip; //sonido
    public AudioClip clipEnd; //sonido al finalizar partida
    public AudioClip[] figuraClip; 
    [SerializeField] public TextMeshProUGUI TextoMonedas; //monedas
    public GameObject Canvas;//{ get; }

    //public AudioClip clipBurbuja;
    //privados
    private Rigidbody2D Rigidbody2D;
    private float Horizontal = 0f;
    private bool MoveLeft;
    private bool MoveRight;
    //private CharacterController m_char;

    //variable de cantidad de monedas
    public string coinsPrefs { get { return "Monedas"; } }
    public int currentCoins { get; set; }

    //AudioSource audioSource;

    //mover hacia los lados
    //public bool SwipeLeft;
    //public bool SwipeRight;
    //public float XValue;
    //float NewXPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //formasSprite[0] = formasSprite[0].GetComponent<SpriteRenderer>();
        //triangulo.sprite = "";
        //changeFormas();
        Image = GameObject.Find("ImageCambiante").GetComponent<Image>();

        //Image.sprite = formasArr[1];
        //m_char = GetComponent<CharacterController>();
        MoveLeft = false;
        MoveRight = false;
        //Horizontal = 0;//-1f;
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        changeFormas();
        //se ejecuta el sonido al iniciar el juego
        gameObject.AddComponent<AudioSource>();
        PlaySound();
        Rigidbody2D.velocity = new Vector2(0, 0);

        //Debug.Log(Horizontal);
        //Debug.Log(Rigidbody2D.transform.position.x);
        currentCoins = PlayerPrefs.GetInt(coinsPrefs, 0);
        TextoMonedas.text = $"{currentCoins}";

    }


    //cuando se presiona el boton izquierdo
    public void PointerDownLeft()
    {
        MoveLeft = true;
    }

    //cuando  no se presiona el boton izquierdo
    public void PointerUpLeft()
    {
        MoveLeft = false;
    }

    //cuando se presiona el boton derecho
    public void PointerDownRight()
    {
        MoveRight = true;
    }

    //cuando  no se presiona el boton derecho
    public void PointerUpRight()
    {
        MoveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal = Input.GetAxisRaw("Horizontal");
        Movement();
        //Rigidbody2D.transform.position = new Vector3(Horizontal, Rigidbody2D.transform.position.y, Rigidbody2D.transform.position.z);
        //Debug.Log(Horizontal);
        //Debug.Log(Rigidbody2D.transform.position.x);
        MovementHighway();
        InfiniteHighway();
        //m_char.Move((NewXPos - transform.position.x) * Vector2.right);
        //Rigidbody2D.MovePosition((NewXPos - transform.position.x) * Vector2.right);
    }

    //carretera en movimiento infinito
    void MovementHighway()
    {
        highway.transform.position = new Vector3(highway.transform.position.x,highway.transform.position.y - 0.8f * Time.deltaTime * speed, highway.transform.position.z);
        foreach (var item in formas)
        {
            item.transform.position = new Vector3(item.transform.position.x,item.transform.position.y-0.8f* Time.deltaTime * speed, item.transform.position.z);
        }
    }

    void InfiniteHighway()
    {
        if(highway.transform.position.y <= start.position.y)
        {
            highway.transform.position = new Vector3(highway.transform.position.x,end.transform.position.y,highway.transform.position.z);
            foreach (var item in formas)
            {
                item.transform.position = new Vector3(item.transform.position.x, end.transform.position.y,item.transform.position.z);
            }
            //cada vez que pasa el personaje por una forma se actualiza a diferente forma
            changeFormas();
        }
    }
    public void Movement()
    {
        //SwipeLeft = Input.GetKeyDown(KeyCode.A);
        //SwipeRight = Input.GetKeyDown(KeyCode.D);
        ////si se presiona el boton izquierdo
        //if (MoveLeft || SwipeLeft)
        //{
        //    //Horizontal = -speedMov;
        //    if (m_SIDE == SIDE.Mid)
        //    {
        //        NewXPos = -XValue;
        //        m_SIDE = SIDE.Left;
        //        Debug.Log("mov");
        //    }
        //    else if (m_SIDE == SIDE.Right)
        //    {
        //        NewXPos = 0;
        //        m_SIDE = SIDE.Mid;

        //    }
        //}

        ////si se presiona el boton derecho
        //else if(MoveRight || SwipeRight)
        //{
        //    //Horizontal = speedMov;
        //    if (m_SIDE == SIDE.Mid)
        //    {
        //        NewXPos = XValue;
        //        m_SIDE = SIDE.Right;

        //    }
        //    else if (m_SIDE == SIDE.Left)
        //    {
        //        NewXPos = 0;
        //        m_SIDE = SIDE.Mid;

        //    }
        //}
        //else{
        //    Horizontal = 0;
        //}
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)|| MoveLeft)
        {
            Debug.Log("a");
            Rigidbody2D.velocity = new Vector2(-0.5f, 0);
            StartCoroutine(stopLaneCh());

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)|| MoveRight)
        {
            Rigidbody2D.velocity = new Vector2(0.5f, 0);
            StartCoroutine(stopLaneCh());
        }
    }

    IEnumerator stopLaneCh()
    {
        yield return new WaitForSeconds(1f);
        Rigidbody2D.velocity = new Vector2(0,0);
    }

    private void FixedUpdate() 
    {
        //Rigidbody2D.velocity = new Vector2(Horizontal,Rigidbody2D.velocity.y);
        //m_char.Move((Horizontal - transform.position.x) * Vector3.right);
        //Rigidbody2D.transform.position = new Vector3(Horizontal, Rigidbody2D.transform.position.y, Rigidbody2D.transform.position.z);
    }

    void changeFormas()
    {
        var numeros = new List<int>();
        //Iteramos hasta que la lista tenga 10 elementos
        while (numeros.Count < 3)
        {
            
            int numeroAleatorio = new Random().Next(0, 4);

            //S�lo si el n�mero generado no existe en la lista se agrega
            if (!numeros.Contains(numeroAleatorio))
            {
                numeros.Add(numeroAleatorio);
                //Debug.Log(numeroAleatorio);
            }
        }


        int imageAleatorio = new Random().Next(0,2);
        Image.sprite = formasArr[numeros[imageAleatorio]];

        //Debug.Log(Image.sprite);
        
        int i = 0;
        foreach(var item in formasSprite)
        {
            //Debug.Log(numeros[i]);
            item.sprite = formasArr[numeros[i]];
            i++;
        }


    }

    public void PlaySound()
    {
        source.PlayOneShot(clip);
    }

    public void PlaySoundEndGame()
    {
        source.PlayOneShot(clipEnd);
    }

    public void PlaySoundFigura(string clip)
    {
        foreach (AudioClip clipPlay in figuraClip)
        {
            //Debug.Log(clipPlay.name == clip);
            //Debug.Log(clip);
            //Debug.Log();
            if (clip.StartsWith(clipPlay.name, StringComparison.CurrentCultureIgnoreCase))
            {
                source.PlayOneShot(clipPlay);
            }
        }

        //source.PlayOneShot(figuraClip[clip]);
        
    }

}
