using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float destroyZ = -10f;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameEnded()) return;

        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (transform.position.z <= destroyZ)
        {
            Destroy(gameObject);
        }
    }
}