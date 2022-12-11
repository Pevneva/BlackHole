using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _type;
    
    public ItemType Type => _type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeAffect(this);
            Destroy(gameObject);
        }   
    }
}
