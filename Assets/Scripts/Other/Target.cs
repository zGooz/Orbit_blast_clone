
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public event UnityAction HitTarget;
    public Gun Gun { get; set; }
    public Transform PlaceTransform { get; set; }

    [SerializeField] Score _score;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (PlaceTransform == null) return;
        _transform.position = PlaceTransform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;
        var bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            HitTarget?.Invoke();

            if (Gun != null) Gun.Reload();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
