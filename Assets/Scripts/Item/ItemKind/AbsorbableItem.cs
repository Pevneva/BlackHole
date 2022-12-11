using UnityEngine;

public class AbsorbableItem : Item
{
    [SerializeField] private float _red;
    [SerializeField] private float _green;
    [SerializeField] private float _blue;

    public float Red => _red;
    public float Green => _green;
    public float Blue => _blue;
}