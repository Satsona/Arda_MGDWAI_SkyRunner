using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Animated UI")]
    [SerializeField] private RectTransform titleText;
    [SerializeField] private RectTransform playButton;
    
    [SerializeField] private RectTransform settingsButton;
    
    [SerializeField] private RectTransform quitButton;



    private void Start()
    {
        Time.timeScale = 1f;

        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        AnimateMenu();
    }

    private void AnimateMenu()
    {
        if (titleText != null)
        {
            titleText.localScale = Vector3.zero;
            titleText.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }

        if (playButton != null)
        {
            playButton.localScale = Vector3.zero;
            playButton.DOScale(Vector3.one, 0.5f)
                .SetDelay(0.2f)
                .SetEase(Ease.OutBack);
        }
        
        if (settingsButton != null)
        {
            settingsButton.localScale = Vector3.zero;
            settingsButton.DOScale(Vector3.one, 0.5f)
                .SetDelay(0.2f)
                .SetEase(Ease.OutBack);
        }
        
        if (quitButton != null)
        {
            quitButton.localScale = Vector3.zero;
            quitButton.DOScale(Vector3.one, 0.5f)
                .SetDelay(0.2f)
                .SetEase(Ease.OutBack);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}