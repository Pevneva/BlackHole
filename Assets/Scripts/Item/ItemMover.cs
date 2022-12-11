using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemMover : MonoBehaviour
{
    private bool _isGravityApplied;
    private Rigidbody _body;
    private Rigidbody _playerBody;
    private bool _isSideImpulseDone;
    private Vector3 _directionToPlayer;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isGravityApplied == false)
            return;

        Move();
    }

    public void SetEnablingGravity(bool isApplied, Rigidbody playerRigidbody)
    {
        _playerBody = playerRigidbody;
        _isGravityApplied = isApplied;
        _isSideImpulseDone = false;

        if (_isGravityApplied == false)
            _body.velocity = Vector3.zero;
    }

    private void Move()
    {
        if (IsStartMovement())
            DoSideImpulse();

        Vector3 direction = (_playerBody.transform.position - _body.position).normalized;
        float distance = (_playerBody.transform.position - _body.position).magnitude;
        float strength = ParamsController.Gravity.GRAVITY_FORCE_FACTOR * _body.mass * _playerBody.mass / distance;
        _body.AddForce(new Vector3(direction.x, 0, direction.z) * strength);

        bool IsStartMovement()
        {
            return _isSideImpulseDone == false;
        }
    }

    private void DoSideImpulse()
    {
        _body.AddForce(0, 0, ParamsController.Gravity.SIDE_FORCE);
        _isSideImpulseDone = true;
    }
}