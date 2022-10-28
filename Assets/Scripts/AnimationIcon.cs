using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIcon : MonoBehaviour
{

    [SerializeField] RectTransform icon;

    public void iconRestart()
    {
        LeanTween.rotate(icon, 360f, 0.5f);
    }

}
