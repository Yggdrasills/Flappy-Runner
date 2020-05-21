using UnityEngine;

namespace FlappyRunner.Utils.Extensions
{
    public static class Extensions
    {
        public static Vector3 SetVectorY(this Vector3 vector, float y)
        {
            vector.y = y;
            return vector;
        }

        public static Vector2 SetVectorY(this Vector2 vector, float y)
        {
            vector.y = y;
            return vector;
        }

        public static bool isNearlyEqual(this float self, float number, float epsilon)
        {
            return self >= number - epsilon && self <= number + epsilon;
        }

        public static void AddPositionX(this Transform xyz, float x)
        {
            Vector3 pos = xyz.position;
            pos.x += x;
            xyz.position = pos;
        }

        public static void SetPositionX(this Transform xyz, float x)
        {
            Vector3 pos = xyz.position;
            pos.x = x;
            xyz.position = pos;
        }
    }
}