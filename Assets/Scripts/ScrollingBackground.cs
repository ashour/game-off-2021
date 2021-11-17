using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;

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

        _material.mainTextureOffset = new Vector2(
            _material.mainTextureOffset.x,
            _material.mainTextureOffset.y + _scrollSpeed * Time.deltaTime);
    }

    public void Scroll(bool active) => _isScrolling = active;
}
