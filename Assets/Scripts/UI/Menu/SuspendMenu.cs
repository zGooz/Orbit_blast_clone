
using UnityEngine;
using UnityEngine.Events;

public class SuspendMenu : MonoBehaviour // TODO : rename class
{
    public event UnityAction GameIsResume;

    [SerializeField] private Button _gameResumeButton;
    [SerializeField] private Button _goToMainMenuButton;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _menuInGameLevel; // TODO : rename variable
    [SerializeField] private GameObject _rotors;
    [SerializeField] private GameObject _spawner;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _score;

    private void OnEnable()
    {
        _gameResumeButton.Click += ResumeGame;
        _goToMainMenuButton.Click += GoToMainMenu;
    }

    private void OnDisable()
    {
        _gameResumeButton.Click -= ResumeGame;
        _goToMainMenuButton.Click -= GoToMainMenu;
    }

    private void ResumeGame()
    {
        GameIsResume?.Invoke();

        _rotors.SetActive(true);
        _spawner.SetActive(true);
        _player.SetActive(true);
        _score.SetActive(true);
        _menuInGameLevel.SetActive(true);
        _panel.SetActive(true);

        gameObject.SetActive(false);
    }

    private void GoToMainMenu()
    {
        _rotors.SetActive(false);
        _spawner.SetActive(false);
        _player.SetActive(false);
        _panel.SetActive(false);
        _score.SetActive(false);
        _mainMenu.SetActive(true);

        gameObject.SetActive(false);
    }
}
