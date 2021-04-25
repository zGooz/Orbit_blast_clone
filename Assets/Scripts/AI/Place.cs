
using UnityEngine;

public class Place : MonoBehaviour
{
    public float Angle { get; set; } = 0f;
    public RectTransform RectangleTransform { get; set; } = null;
    public Rotor Rotor { get; set; } = null;
    public GameObject Target { get; set; } = null;
    public Transform Container { get; set; } = null;
    public Gun Gun { get; set; } = null;

    private float _radius;
    private Transform _transform;

    private void Start()
    {
        _radius = RectangleTransform.rect.width / 2;
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        var positionOftarget = MethodsBox.GetPositionRelativeOfCentr (
                                    RectangleTransform,
                                    Angle + Rotor.Angle, _radius
                                );

        _transform.position = positionOftarget;
    }

    public GameObject CreateTarget()
    {
        if (Target == null || Container == null)
        {
            return null;
        }

        var instance = Instantiate(Target, _transform.position, Quaternion.identity, Container);
        var target = instance.GetComponent<Target>();

        target.Gun = Gun;

        return instance;
    }
}
