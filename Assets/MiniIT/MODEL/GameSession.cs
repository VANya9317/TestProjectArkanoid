using MiniIT.OBJECT;
using MiniIT.UTILS;
using UnityEngine;

namespace MiniIT.MODEL
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionEffect;
        [SerializeField] private Ball ball;
        [SerializeField] public int score;
        [SerializeField] public int allAster;
        
        public static GameSession Instance;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
        }

        public void StartGame()
        {
            ball.gameObject.SetActive(true);
        }

        public void AsteroidDestroyed(Asteroid asteroid)
        {
            explosionEffect.transform.position = asteroid.transform.position;
            explosionEffect.Play();

            if (asteroid.size < 0.7f) 
            {
                score += 100;
            } 
            else if (asteroid.size < 1.4f) 
            {
                score += 50;
            } 
            else 
            {
                score += 25;
            }
            
            if (allAster == 0)
            {
                FindObjectOfType<Ball>().gameObject.SetActive(false);
                WindowUtils.CreateWindow("WinMenu");
            }
        }
        
        public void OnLoseMenu()
        {
            WindowUtils.CreateWindow("LoseMenu");
        }
    }
}