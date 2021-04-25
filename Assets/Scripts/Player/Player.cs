
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rotor _rotor;
    private RectTransform _rectTransformOfRotor;
    private Transform _transform;
    private float _radius;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rectTransformOfRotor = _rotor.GetComponent<RectTransform>();
        _radius = _rectTransformOfRotor.rect.width / 2;
    }

    private void Update()
    {
        var positionOftarget = MethodsBox.GetPositionRelativeOfCentr(
                                _rectTransformOfRotor,
                                _rotor.Angle, _radius
                            );

        _transform.position = positionOftarget;
    }
}
