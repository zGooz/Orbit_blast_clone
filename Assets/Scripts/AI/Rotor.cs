
using UnityEngine;

public class Rotor : MonoBehaviour
{
    public float Angle { get; private set; }
    public bool IsRotation
    {
        get { return _isRotation; }
        set { _isRotation = value; }
    }

    [SerializeField] private RectTransform _rectTransformOfCanvas;
    [SerializeField] private Pendulum _pendulum;
    [SerializeField] [Range(-1, 1)] private float _sign = 1;
    [SerializeField] bool _isRotation;

    private void Awake()
    {
        var height = _rectTransformOfCanvas.rect.height;
        var rectangleTransform = GetComponent<RectTransform>();
        var position = _rectTransformOfCanvas.position;

        rectangleTransform.position = new Vector3(position.x, position.y - height / 7, 0);
    }

    private void Update()
    {
        var angle = Angle + _pendulum.GetSign();
        if (IsRotation) angle += _sign;
        Angle = ( angle >= 360 ) ? angle - 360 : ( angle <= 0 ? angle + 360 : angle );
    }
}
