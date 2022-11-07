using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource sound;
    public AudioClip soundMenu;

    public void SoundButton()
    {
        sound.clip = soundMenu;
        sound.enabled = false;
        sound.enabled = true;
    }

}
