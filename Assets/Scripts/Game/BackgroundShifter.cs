using UnityEngine;

namespace FlappyRunner.Game
{
    public class BackgroundShifter : MonoBehaviour
    {
        [SerializeField] private Transform[] _backgrounds = null;
        [SerializeField] private float _speed = 5;
        [SerializeField] private float _offset = 27;

        private Vector3 _newBGPosition;
        private float _bgAmount;

        private void Awake()
        {
            _bgAmount = _backgrounds.Length;
            _newBGPosition = Vector3.right * _offset * 2;
        }

        private void Update()
        {
            for (int i = 0; i < _bgAmount; i++)
            {
                _backgrounds[i].transform.Translate(Vector2.left * _speed * Time.deltaTime);

                if (_backgrounds[i].transform.position.x > -_offset) continue;

                _backgrounds[i].transform.position += _newBGPosition;
            }
        }
    }
}