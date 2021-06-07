using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace BeatsaberOptimizer.Objects
{
    public class ObstacleDetector : MonoBehaviour
    {
        public List<ObstacleController> intersectingObstacles { get; protected set; } = new List<ObstacleController>();
        protected BoxCollider collider = null!;
        protected Rigidbody rigidbody = null!;

        [Inject]
        internal void Inject() { }

        protected void Awake()
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;

            collider = gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.size = Vector3.one * 0.05f;

            gameObject.layer = 9;

            List<int> layerList = Enumerable.Range(0, 31).ToList();
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 11)
                return;

            Transform obstacle = other.transform.parent.parent;
            intersectingObstacles.Add(obstacle.GetComponent<ObstacleController>());
        }

        protected void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != 11)
                return;

            Transform obstacle = other.transform.parent.parent;
            intersectingObstacles.Remove(obstacle.GetComponent<ObstacleController>());
        }
    }
}
