using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _speed;
    private Vector3 _moveDirection;
    private Coroutine _increasingSpeed;
    private Player _player;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _player.TemporaryBoosterTaken += OnTemporaryBoosterTaken;
        _moveDirection = Vector3.zero;
        _speed = ParamsController.PlayerMovingData.SPEED;
    }

    public void StopMoving()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.isKinematic = true;
        _moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += Time.deltaTime * _speed * _moveDirection.normalized;
    }

    private void OnTemporaryBoosterTaken(float time)
    {
        _increasingSpeed = StartCoroutine(IncreaseSpeed(time));
    }

    private IEnumerator IncreaseSpeed(float time)
    {
        if (_increasingSpeed != null)
        {
            StopCoroutine(_increasingSpeed);
            _speed = ParamsController.PlayerMovingData.SPEED;
        }
        _speed *= ParamsController.PlayerMovingData.INCREASED_SPEED_FACTOR;
        yield return new WaitForSeconds(time);
        
        _speed = ParamsController.PlayerMovingData.SPEED;
    }
}