
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _container;
    [SerializeField] private Rotor _rotor;
    [SerializeField] private Button _panel;
    [SerializeField] private float _shootPower = 2f;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _prompt;
    [SerializeField] private Environment _environment;
    private bool _isCanShoot = true;
    private bool _isFirstClickDone = false;
    private GameObject _bullet = null;
    private Bullet _bulletProperty = null;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _panel.Click += Shoot;
    }

    private void OnDisable()
    {
        _panel.Click -= Shoot;

        if (_bulletProperty != null)
        {
            _bulletProperty.BulletIsDestroy -= Reload;
        }
    }

    private void Shoot()
    {
        if (_isFirstClickDone == false)
        {
            _isFirstClickDone = true;
            _spawner.CreateTarget();

            Destroy(_prompt);
            return;
        }

        if (_isCanShoot)
        {
            var angle = _rotor.Angle * Mathf.Deg2Rad;
            var transformOfContainer = _container.transform;
            var place = _transform.position;

            place.Set(place.x, place.y, 0);

            _bullet = Instantiate(_bulletPrefab, place, Quaternion.identity, transformOfContainer);

            _bulletProperty = _bullet.GetComponent<Bullet>();
            _bulletProperty.Value = _shootPower;
            _bulletProperty.Direction = _rotor.Angle;
            _environment.Bullet = _bulletProperty;

            _bulletProperty.BulletIsDestroy += Reload;
            _bulletProperty.BulletIsDestroy += _environment.GameEnd;
            _isCanShoot = false;
        }
    }

    public void Reload()
    {
        _isCanShoot = true;
    }
}
