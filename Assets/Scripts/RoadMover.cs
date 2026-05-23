using UnityEngine;

public class RoadMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float resetZ = -10f;
    [SerializeField] private float startZ = 10f;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameEnded()) return;

        transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        if (transform.position.z <= resetZ)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = startZ;
            transform.position = newPosition;
        }
    }
}