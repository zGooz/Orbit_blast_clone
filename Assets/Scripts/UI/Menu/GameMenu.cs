
using UnityEngine;
using UnityEngine.Events;

public class GameMenu : MonoBehaviour
{
    public event UnityAction GameIsSuspend;

    [SerializeField] private Button _gameSuspendButton;
    [SerializeField] private GameObject _menuPauseOfGame; // TODO : rename variable
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _rotor;

    private void OnEnable()
    {
        _gameSuspendButton.Click += SuspendGame;
    }

    private void OnDisable()
    {
        _gameSuspendButton.Click -= SuspendGame;
    }

    private void SuspendGame()
    {
        GameIsSuspend?.Invoke();

        _menuPauseOfGame.SetActive(true);
        _score.SetActive(false);
        _rotor.SetActive(false);
        _player.SetActive(false);
        gameObject.SetActive(false);
    }
}
