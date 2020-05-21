using BaseCore.Utils.Messaging;
using FlappyRunner.Game;
using FlappyRunner.Messaging;
using UnityEngine;

namespace FlappyRunner.Enemies
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;
        [SerializeField] private AudioClip _sound = null;

        private void Update()
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) return;

            Signals.Get<PlayerHitSignal>().Dispatch();
            SoundsPlayer.Instance.PlaySound(_sound);
            Destroy(gameObject);
        }
    }
}