using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private Vector2 _direction;
    private Vector2 _startPosition;
    private bool _isDirectionChosen;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        TrySetDirection();

        if (_isDirectionChosen)
            _playerMover.Move(_direction);
    }

    private void Update()
    {
        TrySaveStartData();
        TryResetStartData();
    }

    private void TrySaveStartData()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
            _isDirectionChosen = false;
        }
    }

    private void TryResetStartData()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isDirectionChosen = false;
            _playerMover.StopMoving();
        }
    }

    private void TrySetDirection()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePosition = Input.mousePosition;

            if (Vector2.Distance(_startPosition, currentMousePosition) >
                ParamsController.PlayerInputData.DISTANCE_SENSITIVITY)
            {
                _direction = currentMousePosition - _startPosition;
                _isDirectionChosen = true;
            }
        }
    }
}