using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityCreator : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ItemMover itemMover))
        {
            itemMover.SetEnablingGravity(true, _rigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.TryGetComponent(out ItemMover itemMover))
        {
            itemMover.SetEnablingGravity(false, _rigidbody);
        }
    }
}
