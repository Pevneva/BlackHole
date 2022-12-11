using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemCreator : MonoBehaviour
{
    [Header("Templates")]
    [SerializeField] private ConstantBooster _constantBoosterTemplate;
    [SerializeField] private TemporaryBooster _temporaryBoosterTemplate;
    [SerializeField] private AbsorbableItem _absorbableItemTemplate;
    [Header("Setup")]
    [SerializeField] private Transform _parent;
    [SerializeField] private float _offsetBetweenItems = 2.5f;
    [SerializeField] private float _minX = -100;
    [SerializeField] private float _maxX = 100;
    [SerializeField] private float _minZ = -100;
    [SerializeField] private float _maxZ = 100;
    [SerializeField] private int _countItems = 1000;

    private void Start()
    {
        CreateItems(_constantBoosterTemplate.gameObject, _countItems/3);
        CreateItems(_temporaryBoosterTemplate.gameObject, _countItems/3);
        CreateItems(_absorbableItemTemplate.gameObject, _countItems/3);
    }

    private void CreateItems(GameObject template, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(_minX/_offsetBetweenItems, _maxX/_offsetBetweenItems) * _offsetBetweenItems;
            float randomZ = Random.Range(_minZ/_offsetBetweenItems, _maxZ/_offsetBetweenItems) * _offsetBetweenItems;
                Instantiate(template, new Vector3(randomX, 0, randomZ), Quaternion.identity, _parent);
        }
    }
}