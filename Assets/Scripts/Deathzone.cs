using System.Collections;
using UnityEngine;

namespace GMPR2512.Assignment01
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _respawnDelay = 2f;

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Ball"))
            {
                StartCoroutine(RespawnBall(collider2D.gameObject));
            }
        }

        private IEnumerator RespawnBall(GameObject ball)
        {
            yield return new WaitForSeconds(_respawnDelay);

            Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
            if (ballRB != null)
            {
                ballRB.linearVelocity = Vector2.zero;
                ballRB.angularVelocity = 0f;
            }

            ball.transform.position = _spawnPoint.position;
        }
    }
}