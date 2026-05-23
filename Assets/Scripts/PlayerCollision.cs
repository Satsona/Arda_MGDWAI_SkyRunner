using UnityEngine;
using DG.Tweening;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Transform playerVisual;

    private bool hasHit;

    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        if (other.CompareTag("Obstacle"))
        {
            hasHit = true;

            if (playerVisual != null)
            {
                playerVisual.DOPunchScale(Vector3.one * 0.25f, 0.25f, 8, 0.8f)
                    .SetUpdate(true)
                    .OnComplete(() =>
                    {
                        GameManager.Instance.LoseGame();
                    });
            }
            else
            {
                GameManager.Instance.LoseGame();
            }
        }
    }
}