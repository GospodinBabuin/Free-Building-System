using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementSystemInput : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _selectedPosition;
    private LayerMask _groundLayerMask;

    private void Awake()
    {
        _camera = Camera.main;
        _groundLayerMask = LayerMask.NameToLayer("Ground");
    }

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = _camera.nearClipPlane;

        Ray ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _groundLayerMask))
            _selectedPosition = hit.point;

        return _selectedPosition;
    }
}
