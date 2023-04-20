using UnityEngine;
using UnityEngine.Windows;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField] private Material _previewMaterialsPrefab;
    private Material _previewMaterialInstance;

    private GameObject _previewBuilding;

    private void Awake()
    {
        _previewMaterialInstance = new Material(_previewMaterialsPrefab);
    }

    public void StartShowingPlacementPreview(GameObject prefab)
    {
        _previewBuilding = Instantiate(prefab);
        PreparePreview(_previewBuilding);
    }

    private void PreparePreview(GameObject previewBuilding)
    {
        Renderer[] renderers = previewBuilding.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = _previewMaterialInstance;
            }
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.materials = materials;
        }
    }

    private void ApplyFeedback(bool validity)
    {
        Color color = validity ? Color.white : Color.red;
        _previewMaterialInstance.color = color;
    }

    public void UpdatePosition()
    {
        if (_previewBuilding == null) return;

        _previewBuilding.transform.position = _input.GetSelectedMapPosition();
    }
}
