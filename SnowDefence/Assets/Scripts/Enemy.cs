using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PathCreation.Examples
{
    public class Enemy : MonoBehaviour
    {
        private Transform target;
        private int wavePointIndex = 0;
        
        [Header("PathFollower")]
        public PathCreator pathCreator;
        public GameObject path;
        public EndOfPathInstruction endOfPathInstruction;
        float distanceTravelled;
    
        [Header("Enemy Specs")]
        public float speed = 10f;
        public int life = 100;
        public int damage = 1;

        [SerializeField] private AudioSource risadinha;
        
        private void Start()
        {
            pathCreator = path.GetComponent<PathCreator>();
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                
            }
            
            if (life <= 0)
            {
                Die();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Factory"))
            {
                EndPath();
            }
        }

        private void OnMouseDown()
        {
            if (risadinha != null)
            {
                risadinha.Play();
            }
        }

        void EndPath()
        {
            CharcoalMine.Life = CharcoalMine.Life - damage;
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
        }
    
        void Die()
        {
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
        }
    }
}