using UnityEngine;

namespace GMPR2512.Assignment01
{
    public class Bumper : MonoBehaviour
    {
        [SerializeField] private float _impulse = 8f;
        [SerializeField] private Color _hitColour = Color.white;
        [SerializeField] private float _hitFlashTime = 0.1f;

        private SpriteRenderer _renderer;
        private Color _originalColour;
        private bool _isFlashing = false;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (_renderer != null)
            {
                _originalColour = _renderer.color;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball"))
            {
                Rigidbody2D ballRB = collision.collider.GetComponent<Rigidbody2D>();
                if (ballRB != null)
                {
                    Vector2 dir = (ballRB.position - (Vector2)transform.position).normalized;
                    ballRB.AddForce(dir * _impulse, ForceMode2D.Impulse);
                }

                Flash();
            }
        }

        void Flash()
        {
            if (_renderer == null) return;
            if (_isFlashing) return;

            _isFlashing = true;
            _renderer.color = _hitColour;
            Invoke(nameof(ResetColour), _hitFlashTime);
        }

        void ResetColour()
        {
            _renderer.color = _originalColour;
            _isFlashing = false;
        }
    }
}