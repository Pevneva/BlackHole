using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Player : MonoBehaviour
{
    private MeshRenderer _mesh;
    private Color _color;
    private bool _isGravityAreaIncreased;
    private Coroutine _gravityIncreasing;

    public event Action<float> TemporaryBoosterTaken;
    
    private void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _color = _mesh.material.color;
    }

    public void TakeAffect(Item item)
    {
        switch (item.Type)
        {
            case ItemType.ConstantBooster:
                ConstantBooster constantBooster = (ConstantBooster) item;
                TryIncreaseSize(constantBooster.AddedSize);
                break;

            case ItemType.AbsorbableItem:
                AbsorbableItem absorbableItem = (AbsorbableItem) item;
                AddRGB(absorbableItem.Red, absorbableItem.Green, absorbableItem.Blue);

                break;

            case ItemType.TemporaryBooster:
                TemporaryBooster temporaryBooster = (TemporaryBooster)item;
                TemporaryBoosterTaken?.Invoke(temporaryBooster.BoosterTime);
                break;
        }
    }

    private void TryIncreaseSize(int value)
    {
        if (transform.localScale.x < ParamsController.PlayerShowingData.MAX_SIZE)
        {
            Vector3 resultSize = transform.localScale + (float) value / 100 * new Vector3(1, 1, 1);
            transform.DOScale(resultSize, 1);
        }
    }

    private void AddRGB(float red, float green, float blue)
    {
        Color resultColor = new Color(_color.r + red, _color.g + green, _color.b + blue);
        _color = resultColor;
        _mesh.material.color = resultColor;
    }
}