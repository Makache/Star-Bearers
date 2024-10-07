using UnityEngine;

public class Destination : MonoBehaviour
{
    [SerializeField] private Leader _leader;
    [SerializeField] private PauseMenu _pauseMenu;

    private Vector2 _destinationPosition;

    private void Update()
    {
        if (_pauseMenu.IsPaused) return;

        if (Input.GetMouseButtonDown(0))
        {
            _destinationPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _leader.MoveToPoint(_destinationPosition);
        }
    }
}