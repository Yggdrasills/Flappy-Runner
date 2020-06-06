using UnityEngine;
using DG.Tweening;

namespace FlappyRunner.CharacterControl
{
    public class CharacterMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float _moveOffset = 3;
        [SerializeField] private float _moveDuration = 0.1f;

        private Tweener moveTween;

        public void MoveByY(int direction)
        {
            if (moveTween != null && moveTween.IsActive()) return;

            var currentPosition = transform.position;

            if ((currentPosition.y == _moveOffset && direction == 1) ||
                (currentPosition.y == -_moveOffset && direction == -1))
                return;


            moveTween = transform.DOMoveY(currentPosition.y + _moveOffset * direction, _moveDuration);
        }
    }
}