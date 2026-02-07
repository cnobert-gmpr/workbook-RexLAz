using UnityEngine;

namespace GMPR2512.Assignment01
{
    public class DropTarget : MonoBehaviour
    {
        [SerializeField] private Color _hitColour = Color.gray;
        [SerializeField] private float _resetDelay = 2f;

        private bool _isDown = false;
        private SpriteRenderer _renderer;
        private Color _originalColour;
        private Collider2D _collider;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();

            if (_renderer != null)
            {
                _originalColour = _renderer.color;
            }
        }

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Ball") && !_isDown)
            {
                _isDown = true;

                if (_renderer != null)
                {
                    _renderer.color = _hitColour;
                }

                if (_collider != null)
                {
                    _collider.enabled = false; // disable immediately (no re-trigger)
                }

                Invoke(nameof(ResetTarget), _resetDelay);
            }
        }

        void ResetTarget()
        {
            if (_renderer != null)
            {
                _renderer.color = _originalColour;
            }

            if (_collider != null)
            {
                _collider.enabled = true;
            }

            _isDown = false;
        }
    }
}