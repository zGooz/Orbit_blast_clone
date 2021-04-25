
using UnityEngine;

public class CameraPropertySetter : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransformOfCanvas;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        var position = _rectTransformOfCanvas.position;
        transform.position = new Vector3(position.x, position.y, -10);
        _camera.orthographicSize = _rectTransformOfCanvas.rect.width;
    }
}
