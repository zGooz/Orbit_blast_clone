
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Area : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransformOfRotor;
    [SerializeField] private RectTransform _rectTransformOfCanvas;

    private void Awake()
    {
        var collider = GetComponent<CircleCollider2D>();
        var width = _rectTransformOfRotor.rect.width;
        var height = _rectTransformOfCanvas.rect.height;
        var position = _rectTransformOfCanvas.position;

        collider.radius = width / 2 + 30f;
        transform.position = new Vector3(position.x, position.y - height / 7, 0);
    }
}
