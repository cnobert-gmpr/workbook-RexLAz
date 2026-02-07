using UnityEngine;

namespace GMPR2512.Assignment01
{
    public class PortalGate : MonoBehaviour
    {
        [SerializeField] private Transform _exitPoint;
        [SerializeField] private float _cooldown = 0.3f;
        [SerializeField] private bool _preserveVelocity = true;

        private bool _canTeleport = true;

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (!_canTeleport) return;

            if (collider2D.CompareTag("Ball"))
            {
                Rigidbody2D ballRB = collider2D.GetComponent<Rigidbody2D>();
                if (ballRB == null) return;

                Vector2 savedVel = ballRB.linearVelocity;

                collider2D.transform.position = _exitPoint.position;

                if (_preserveVelocity)
                {
                    ballRB.linearVelocity = savedVel;
                }

                _canTeleport = false;
                Invoke(nameof(ResetTeleport), _cooldown);
            }
        }

        void ResetTeleport()
        {
            _canTeleport = true;
        }
    }
}