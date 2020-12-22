using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWay : MonoBehaviour
{
    [SerializeField] private Transform _wayPoints;
    [SerializeField] private float _speed;
    private Transform[] _points;
    private int _currectPointIndex = 0;

    void Start()
    {
        _points = new Transform[_wayPoints.childCount];
        for (int i = 0; i < _wayPoints.childCount; i++)
        {
            _points[i] = _wayPoints.GetChild(i);
        }
    }

    void Update()
    {
        Transform target = _points[_currectPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        if (transform.position == target.position)
        {
            _currectPointIndex++;
            if(_currectPointIndex>=_points.Length)
            {
                _currectPointIndex = 0;
            }
        }
    }
}
