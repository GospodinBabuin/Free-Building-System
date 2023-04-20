using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    private PlacementSystem _placementSystem;
    private PlacementSystemInput _input;
    private PreviewSystem _preview;
    private void Awake()
    {
        _input = GetComponentInChildren<PlacementSystemInput>();
        _preview = GetComponentInChildren<PreviewSystem>();
    }

    public void StartPlacement(GameObject prefab)
    {
        _placementSystem = new PlacementSystem(_input, _preview, prefab);
    }

    private void StopPlacement()
    {
        
    }
}
