using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnDiamonds : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private int _quantityDiamonds;
    [SerializeField] private GameObject _diamondPrefab;
    private Transform[] _points;

    void Start()
    {
        if (_quantityDiamonds > _spawnPoints.childCount)
            _quantityDiamonds = _spawnPoints.childCount;
        _points = new Transform[_spawnPoints.childCount];
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
        var listPoint = _points.Cast<Transform>().ToList();
        while (_quantityDiamonds >= 0)
        {
            int numberOfPoint = Random.Range(0, listPoint.Count);
            Instantiate(_diamondPrefab, listPoint[numberOfPoint]);
            _quantityDiamonds--;
            listPoint.RemoveAt(numberOfPoint);
        }
    }
}
