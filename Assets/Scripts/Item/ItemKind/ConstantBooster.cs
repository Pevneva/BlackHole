using UnityEngine;

public class ConstantBooster : Item
{
    [SerializeField] private int _addedSize;
    
    public int AddedSize => _addedSize;
}