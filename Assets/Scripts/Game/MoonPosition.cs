using UnityEngine;

namespace FlappyRunner.Game
{
    public class MoonPosition : MonoBehaviour
    {
        [SerializeField] private float _moonPositionX_4x3 = default;
        [SerializeField] private float _moonPositionX_16x9 = default;
        [SerializeField] private float _moonPositionX_21x9 = default;

        private void Awake()
        {
            var cameraAspect = Camera.main.aspect;
            var curPos = transform.position;

            if(cameraAspect > 2)
            {
                curPos.x = _moonPositionX_21x9;
            }
            else if(cameraAspect <= 2f && cameraAspect > 1.5f)
            {
                curPos.x = _moonPositionX_16x9;
            }
            else
            {
                curPos.x = _moonPositionX_4x3;
            }

            transform.position = curPos;
        }
    }
}