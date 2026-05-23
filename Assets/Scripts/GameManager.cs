using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score Settings")]
    [SerializeField] private int targetScore = 150;
    [SerializeField] private float scoreUpdateInterval = 0.2f; // 0.2 sec = 5 score per second

    [Header("UI Texts")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [Header("Win Panel Animation")]
    [SerializeField] private CanvasGroup winCanvasGroup;
    [SerializeField] private RectTransform winTitle;
    [SerializeField] private RectTransform winRestartButton;

    [Header("Lose Panel Animation")]
    [SerializeField] private CanvasGroup loseCanvasGroup;
    [SerializeField] private RectTransform loseTitle;
    [SerializeField] private RectTransform loseRestartButton;

    private int score;
    private int seconds;
    private float scoreTimer;
    private float timeTimer;

    private bool gameEnded;
    private bool isPaused;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        score = 0;
        seconds = 0;
        scoreTimer = 0f;
        timeTimer = 0f;

        gameEnded = false;
        isPaused = false;

        if (pausePanel != null) pausePanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);

        UpdateScoreText();
        UpdateTimeText();
    }

    private void Update()
    {
        if (gameEnded || isPaused) return;

        UpdateScore();
        UpdateTime();
    }

    private void UpdateScore()
    {
        scoreTimer += Time.deltaTime;

        if (scoreTimer >= scoreUpdateInterval)
        {
            scoreTimer = 0f;
            score++;

            UpdateScoreText();

            if (score >= targetScore)
            {
                WinGame();
            }
        }
    }

    private void UpdateTime()
    {
        timeTimer += Time.deltaTime;

        if (timeTimer >= 1f)
        {
            timeTimer = 0f;
            seconds++;

            UpdateTimeText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void UpdateTimeText()
    {
        if (timeText != null)
        {
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;

            timeText.text = "" + minutes.ToString("00") + ":" + remainingSeconds.ToString("00");
        }
    }

    public void PauseGame()
    {
        if (gameEnded) return;

        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        Time.timeScale = 0f;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
            AnimatePanel(winCanvasGroup, winTitle, winRestartButton);
        }
    }

    public void LoseGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        Time.timeScale = 0f;

        if (losePanel != null)
        {
            losePanel.SetActive(true);
            AnimatePanel(loseCanvasGroup, loseTitle, loseRestartButton);
        }
    }

    private void AnimatePanel(CanvasGroup canvasGroup, RectTransform title, RectTransform restartButton)
    {
        if (canvasGroup == null || title == null || restartButton == null) return;

        canvasGroup.alpha = 0f;
        title.localScale = Vector3.zero;
        restartButton.localScale = Vector3.zero;

        Sequence sequence = DOTween.Sequence();
        sequence.SetUpdate(true);

        sequence.Append(canvasGroup.DOFade(1f, 0.25f));
        sequence.Append(title.DOScale(Vector3.one, 0.35f).SetEase(Ease.OutBack));
        sequence.Append(restartButton.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack));
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsGameEnded()
    {
        return gameEnded;
    }
}