using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    [SerializeField] private Renderer groundRenderer;
    [SerializeField] private float scrollSpeed = 2f;

    private Material groundMaterial;
    private float offset;

    private void Awake()
    {
        if (groundRenderer == null)
            groundRenderer = GetComponent<Renderer>();

        groundMaterial = groundRenderer.material;
    }

    private void Update()
    {
        offset += scrollSpeed * Time.deltaTime;

        groundMaterial.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}