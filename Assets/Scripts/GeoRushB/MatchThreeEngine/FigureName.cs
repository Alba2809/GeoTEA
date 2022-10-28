using System.Collections;
using TMPro;
using UnityEngine;

public sealed class FigureName : MonoBehaviour
{

    public static FigureName Instance { get; private set; }

    private string _nameFigure;

    private float typingTime = 0.05f;

    public string SetName(string _name) => _nameFigure = _name;

    public void Name()
    {
        StartCoroutine(showName());
    }

    public IEnumerator showName()
    {
        figurePopText.SetText(sourceText: $"Figura = \n");
        foreach(char ch in _nameFigure)
        {
            figurePopText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    [SerializeField] private TextMeshProUGUI figurePopText;

    private void Awake() => Instance = this;
    

}
