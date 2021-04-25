
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    public event UnityAction BulletIsDestroy;

    public float Value = 0f;
    public float Direction = 0f;

    private Rigidbody2D _body;
    private bool _isHit = false;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var direction = Direction * Mathf.Deg2Rad;
        var sin = Mathf.Sin(direction);
        var cos = Mathf.Cos(direction);
        var speed = new Vector2(Value * cos, Value * sin);

        _body.AddForce(speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D)
        {
            _isHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            if (_isHit == false)
                BulletIsDestroy?.Invoke();
        }

        Destroy(gameObject);
    }
}
