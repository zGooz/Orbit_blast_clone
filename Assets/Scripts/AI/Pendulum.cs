
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public bool IsSwing
    {
        get { return _isSwing; }
        set { _isSwing = value; }
    }

    [SerializeField] private float _amplitude = 0;
    [SerializeField] [Range(-1, 1)] private float _sign = 0.2f;
    [SerializeField] private bool _isSwing;
    private float _deflection = 0;

    private void Update()
    {
        if (IsSwing)
        {
            _deflection += _sign;

            if (_deflection <= -_amplitude || _deflection >= _amplitude)
            {
                _sign *= -1;
            }

            _deflection = Mathf.Clamp(_deflection, -_amplitude, _amplitude);
        }
    }

    public float GetSign()
    {
        return IsSwing ? _sign : 0.0f;
    }
}
