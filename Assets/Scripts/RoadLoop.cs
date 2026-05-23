using UnityEngine;

public class RoadLoop : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float resetZ = -10f;
    [SerializeField] private float roadLength = 20f;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameEnded()) return;

        transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        if (transform.position.z <= resetZ)
        {
            transform.position += Vector3.forward * roadLength;
        }
    }
}