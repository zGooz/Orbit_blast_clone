
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    public event UnityAction GameIsRun;

    [SerializeField] private Button _gameStartButton;
    [SerializeField] private Button _gameEndButton;
    [SerializeField] private GameObject _menuInGameLevel; // TODO : rename variable
    [SerializeField] private GameObject _rotors;
    [SerializeField] private GameObject _spawner;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _prompt;

    private void OnEnable()
    {
        _gameStartButton.Click += StartGame;
        _gameEndButton.Click += EndGame;
    }

    private void OnDisable()
    {
        _gameStartButton.Click -= StartGame;
        _gameEndButton.Click -= EndGame;
    }

    private void StartGame()
    {
        GameIsRun?.Invoke();

        _rotors.SetActive(true);
        _spawner.SetActive(true);
        _player.SetActive(true);
        _panel.SetActive(true);
        _score.SetActive(true);
        _menuInGameLevel.SetActive(true);

        if (_prompt != null) 
            _prompt.SetActive(true);

        gameObject.SetActive(false);
    }

    private void EndGame()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
