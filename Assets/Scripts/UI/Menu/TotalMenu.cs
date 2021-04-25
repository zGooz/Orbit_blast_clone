
using UnityEngine;

public class TotalMenu : MonoBehaviour // TODO : rename class
{
    [SerializeField] private Button _gameReplayButton;
    [SerializeField] private Button _goToMainMenuButton;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _menuInGameLevel; // TODO : rename variable
    [SerializeField] private GameObject _spawner;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _rotors;

    private void OnEnable()
    {
        _gameReplayButton.Click += ReplayGame;
        _goToMainMenuButton.Click += GoToMainMenu;
    }

    private void OnDisable()
    {
        _gameReplayButton.Click -= ReplayGame;
        _goToMainMenuButton.Click -= GoToMainMenu;
    }

    private void ReplayGame()
    {
        _menuInGameLevel.SetActive(true);
        gameObject.SetActive(false);
        _player.SetActive(true);
        _rotors.SetActive(true);
    }

    private void GoToMainMenu()
    {
        _spawner.SetActive(false);
        _player.SetActive(false);
        _panel.SetActive(false);
        _rotors.SetActive(false);
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
