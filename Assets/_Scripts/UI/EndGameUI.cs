using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public static EndGameUI instance;

    [SerializeField] GameObject winLoseContainer;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Button restartLevelButton;
    [SerializeField] Button mainMenuButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;

        winScreen.SetActive(false);

        if (restartLevelButton) restartLevelButton.onClick.AddListener(() =>
        { 
            SceneChanger.Instance?.LoadSingleAsync(SceneManager.GetActiveScene().buildIndex); 
        });
    }

    // Update is called once per frame
    public void ShowWinLose(bool win)
    {
        Utilities.SetCursorLocked(false);
        winLoseContainer.SetActive(true);
        winScreen.SetActive(win);
        loseScreen.SetActive(!win);
    }
}
