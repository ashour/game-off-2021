using UnityEngine;

namespace Scrolling
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] private GameConfig _config;

        private Material _material;

        private bool _isScrolling;

        private void Awake()
        {
            _material = GetComponent<SpriteRenderer>().material;
        }

        private void Update()
        {
            if (!_isScrolling)
            {
                return;
            }

            var newYOffset =
                _material.mainTextureOffset.y +
                _config.AutoScrollSpeed * Time.deltaTime;

            _material.mainTextureOffset = new Vector2(
                _material.mainTextureOffset.x, newYOffset);
        }

        public void Scroll(bool active) => _isScrolling = active;
    }
}
