using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementSystem : MonoBehaviour
{
    private PlacementSystemInput _input;
    private PreviewSystem _preview;

    private GameObject _building;

    public PlacementSystem(PlacementSystemInput input, PreviewSystem preview, GameObject building)
    {
        _input = input;
        _preview = preview;
        _building = building;

        _preview.StartShowingPlacementPreview(building);
    }

    private void Update()
    {
        if (_previewBuilding == null) return;

        _previewBuilding.transform.position = _input.GetSelectedMapPosition();
    }

    private void SpawnBuilding()
    {
        if (_previewBuilding == null || _building == null) return;

        Instantiate(_building, _previewBuilding.transform.position, _previewBuilding.transform.rotation);

        StopPlacement();
    }

    private void StopPlacement()
    {
        Destroy(_previewBuilding);

        Destroy(this);
    }

    private void OnSelect(InputAction action)
    {
        SpawnBuilding();
    }

    private void OnExit(InputAction action)
    {
        StopPlacement();
    }
}
