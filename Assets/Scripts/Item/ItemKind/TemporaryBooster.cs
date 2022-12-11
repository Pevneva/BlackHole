using UnityEngine;

public class TemporaryBooster : Item
{
    [SerializeField] private float _boosterTime;

    public float BoosterTime => _boosterTime;
}