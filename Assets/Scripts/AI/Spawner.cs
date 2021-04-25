
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour // TODO : rename class
{
    [SerializeField] private RectTransform _rectTransformInside;
    [SerializeField] private RectTransform _rectTransformOutside;
    [SerializeField] private Rotor _rotor;
    [SerializeField] private GameObject _place;
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private Gun _gun;
    [SerializeField] private int _amountOfSides; // TODO : rename variable
    [SerializeField] private Score _score;
    private readonly List<GameObject> _places = new List<GameObject>();
    private GameObject _target = null;

    private void OnEnable()
    {
        SpawnTargets();
    }

    private void OnDisable()
    {
        foreach (var place in _places)
        {
            Destroy(place);
        }
    }

    private void SpawnTargets() // TODO : rename method
    {
        var radius = _rectTransformInside.rect.width / 2;
        var step = 360 / _amountOfSides;

        for (var i = 0; i < 360; i += step)
        {
            var positionOftarget = MethodsBox.GetPositionRelativeOfCentr (
                                        _rectTransformInside,
                                        i, radius
                                    );

            var placeInstance = Instantiate(_place, positionOftarget, Quaternion.identity, _container);
            var place = placeInstance.GetComponent<Place>();

            place.Angle = i;
            place.RectangleTransform = _rectTransformOutside;
            place.Rotor = _rotor;
            place.Container = _container;
            place.Target = _targetPrefab;
            place.Gun = _gun;

            _places.Add(placeInstance);
        }
    }

    public void CreateTarget()
    {
        var index = Random.Range(0, _places.Count);
        var placeObject = _places[index];
        var place = placeObject.GetComponent<Place>();
        var placeTransform = placeObject.GetComponent<Transform>();

        if (_target == null)
        {
            _target = place.CreateTarget();
            var target = _target.GetComponent<Target>();
            target.HitTarget += ResetTarget;
            target.HitTarget += _score.UpScore;
            target.PlaceTransform = placeTransform;
        }
    }

    private void ResetTarget()
    {
        var target = _target.GetComponent<Target>();
        target.HitTarget -= ResetTarget;
        target.HitTarget -= _score.UpScore;
        _target = null;
        CreateTarget();
    }
}
