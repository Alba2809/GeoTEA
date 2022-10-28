using TMPro;
using UnityEngine;

public sealed class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameObject menuGameEnd;
    [SerializeField] private RectTransform menuEnd;

    MenuGameEnd me = new MenuGameEnd();

    //audio
    [SerializeField] private AudioClip endSound;
    [SerializeField] private AudioSource audioSource;

    public static ScoreCounter Instance { get; private set; }

    private int _score = 0;
    private int finalScore = 200;

    public bool scoreReached = false;

    public void plusScore(int x)
    {
        _score += x;
        scoreText.SetText(sourceText: $"Score = {_score}");
    }

    public int Score
    {
        get => _score;

        set
        {
            if (_score == value) return;

            _score = value;

            scoreText.SetText(sourceText: $"Score = {_score}");

            if (scoreReached)
            {
                _score = 0;
                value = 0;
                scoredR(0);
            }
            else scoredR(_score);
        }
    }

    public void scoredR(int score)
    {
        if (score >= finalScore)
        {
            scoreReached = true;

            menuGameEnd.SetActive(true);

            LeanTween.scale(menuEnd, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);

            audioSource.PlayOneShot(endSound);

            me.PlusCoins();
        }
        else scoreReached = false;
        Debug.Log("scoreReached: " + scoreReached);
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() => Instance = this;

    

}
