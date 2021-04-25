
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Bullet Bullet { get; set; }

    [SerializeField] private Rotor _insideRotor;
    [SerializeField] private Rotor _outsideRotor;
    [SerializeField] private Pendulum _insidePendulum;
    [SerializeField] private Pendulum _outsidePendulum;
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _totalMenu;
    [SerializeField] private Score _score;
    [SerializeField] private GameObject _rotors;
    [SerializeField] private GameObject _player;

    public void GameEnd()
    {
        _totalMenu.SetActive(true);
        _gameMenu.SetActive(false);
        _rotors.SetActive(false);
        _player.SetActive(false);
        _score.Reset();

        if (Bullet != null)
        {
            Bullet.BulletIsDestroy -= GameEnd;
        }
    }
}
