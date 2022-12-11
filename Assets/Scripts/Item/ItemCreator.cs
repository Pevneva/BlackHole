using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemCreator : MonoBehaviour
{
    [Header("Templates")] [SerializeField] private ConstantBooster _constantBoosterTemplate;
    [SerializeField] private TemporaryBooster _temporaryBoosterTemplate;
    [SerializeField] private AbsorbableItem _absorbableItemTemplate;
    [Header("Setup")] [SerializeField] private Transform _parent;
    [SerializeField] private float _cellSize = 2.5f;
    [SerializeField] private float _minX = -100;
    [SerializeField] private float _maxX = 100;
    [SerializeField] private float _minZ = -100;
    [SerializeField] private float _maxZ = 100;
    [SerializeField] private int _countItems = 1000;

    private Vector3 _startPosition;
    private List<Vector3Int> _bisyCells = new List<Vector3Int>();

    private void Start()
    {
        CreateItems(_constantBoosterTemplate.gameObject, _countItems / 3);
        CreateItems(_temporaryBoosterTemplate.gameObject, _countItems / 3);
        CreateItems(_absorbableItemTemplate.gameObject, _countItems / 3);
    }

    private void CreateItems(GameObject template, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(_minX / _cellSize, _maxX / _cellSize) *
                            _cellSize;
            float randomZ = Random.Range(_minZ / _cellSize, _maxZ / _cellSize) *
                            _cellSize;

            Vector3 newPosition = new Vector3(randomX, 0, randomZ);

            TryCreate(template, WorldToGridPosition(newPosition), newPosition);
        }
    }

    private bool TryCreate(GameObject template, Vector3Int gridPosition, Vector3 worldPosition)
    {
        if (_bisyCells.Contains(gridPosition))
            return false;
        else
            _bisyCells.Add(gridPosition);

        if (template == null)
            return false;

        Instantiate(template, worldPosition, Quaternion.identity, _parent);

        return true;
    }

    private Vector3Int WorldToGridPosition(Vector3 worldPosition)
    {
        return new Vector3Int(
            (int) ((worldPosition.x - _startPosition.x) / _cellSize),
            0,
            (int) ((worldPosition.z - _startPosition.z) / _cellSize));
    }
}