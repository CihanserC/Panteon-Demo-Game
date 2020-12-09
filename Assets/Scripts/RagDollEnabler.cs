using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RagDollEnabler : MonoBehaviour
    {
        private Rigidbody[] _rigidBodies;

        [SerializeField] private Animator _animator;
        // Start is called before the first frame update
        void Awake()
        {
            if (_animator == null)
            _animator = GetComponent<Animator>();
            _rigidBodies = GetComponentsInChildren<Rigidbody>();
            DisableRagdoll();
        }

        private void DisableRagdoll()
        {
            foreach (var rigidBody in _rigidBodies)
            {
                rigidBody.isKinematic = true;
                rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            }

            _animator.enabled = true;
        }

        public void EnableRagdoll(Vector3 velocity)
        {
            foreach (var rigidBody in _rigidBodies)
            {
                rigidBody.isKinematic = false;
                rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                //rigidBody.velocity = velocity;
            }

             _animator.enabled = false;
        }
    }

