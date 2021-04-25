
using UnityEngine;

public static class MethodsBox // TODO : rename class
{
    // TODO : rename method
    public static Vector3 GetPositionRelativeOfCentr(RectTransform _transform, float angle, float radius)
    {
        angle *= Mathf.Deg2Rad;
        var cos = Mathf.Cos(angle);
        var sin = Mathf.Sin(angle);
        var positionOfParent = _transform.position;
        var addition = new Vector3(radius * cos, radius * sin, 0);
        
        return positionOfParent + addition;
    }
}
