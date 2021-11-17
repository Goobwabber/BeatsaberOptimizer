using IPA.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace BeatsaberOptimizer.Objects
{
    public class ObstacleDetector : MonoBehaviour
    {
        public const int MainObjectLayer = 9;
        public const int WallObjectLayer = 11;
        public const float ColliderSize = 0.05f;

        public List<ObstacleController> IntersectingObstacles { get; private set; } = new ();
        private BoxCollider _collider = null!;
        private Rigidbody _rigidbody = null!;
        private PlayerTransforms _playerTransforms;

        private FieldAccessor<PlayerTransforms, Transform>.Accessor _headTransformAccessor
            = FieldAccessor<PlayerTransforms, Transform>.GetAccessor("_headTransform");

        internal ObstacleDetector(
            PlayerTransforms playerTransforms)
        {
            _playerTransforms = playerTransforms;
        }

        protected void Awake()
        {
            Transform headTransform = _headTransformAccessor(ref _playerTransforms);
            gameObject.transform.SetParent(headTransform);
            gameObject.layer = MainObjectLayer;

            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;

            _collider = gameObject.AddComponent<BoxCollider>();
            _collider.isTrigger = true;
            _collider.size = Vector3.one * ColliderSize;
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 11)
                return;

            Transform obstacle = other.transform.parent.parent;
            IntersectingObstacles.Add(obstacle.GetComponent<ObstacleController>());
        }

        protected void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != WallObjectLayer)
                return;

            Transform obstacle = other.transform.parent.parent;
            IntersectingObstacles.Remove(obstacle.GetComponent<ObstacleController>());
        }
    }
}
