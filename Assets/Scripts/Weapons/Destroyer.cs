using UnityEngine;

namespace Weapons
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private CollisionNotifier _collisionNotifier;

        [Tooltip("If provided, the destroyed object will be the first parent matching the given tag")]
        [SerializeField] private string _destroyParentWithTag;

        private void OnEnable()
        {
            _collisionNotifier.OnTriggered += DestroyGameObject;
            _collisionNotifier.OnCollided += DestroyGameObject;
        }

        private void OnDisable()
        {
            _collisionNotifier.OnTriggered -= DestroyGameObject;
            _collisionNotifier.OnCollided -= DestroyGameObject;
        }

        private void DestroyGameObject(GameObject other)
        {
            if (string.IsNullOrEmpty(_destroyParentWithTag))
            {
                Destroy(other);
            }
            else
            {
                var current = other.transform;

                while (!current.CompareTag(_destroyParentWithTag))
                {
                    if (current == current.root)
                    {
                        Debug.LogWarning(
                            "Could not finding parent object matching" +
                            $" tag {_destroyParentWithTag}");
                        return;
                    }

                    current = current.parent;
                }

                Destroy(current.gameObject);
            }
        }
    }
}
