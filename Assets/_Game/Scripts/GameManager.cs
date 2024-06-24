using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string IsRestarted = nameof(IsRestarted);

    [SerializeField] TubeCollisionHandler _tubeCollisionHandler;
    [SerializeField] GameObject _startScreen;
    [SerializeField] GameObject _gameoverScreen;

    private void OnEnable()
    {
        _tubeCollisionHandler.TubeTouched += StopGame;
    }

    private void OnDisable()
    {
        _tubeCollisionHandler.TubeTouched -= StopGame;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(IsRestarted) == 1)
        {
            PlayerPrefs.SetInt(IsRestarted, 0);
            StartGame();
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void StartGame()
    {
        DisableStartScreen();
        Time.timeScale = 1f;
    }

    public void DisableStartScreen()
    {
        _startScreen.SetActive(false);
    }

    public void StopGame()
    {
        EnableGameoverScreen();
        Time.timeScale = 0f;
    }

    public void EnableGameoverScreen()
    {
        _gameoverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt(IsRestarted, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
