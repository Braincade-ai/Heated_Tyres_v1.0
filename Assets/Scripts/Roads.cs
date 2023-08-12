using UnityEngine;

namespace Road_namespace
{
    public enum RoadType
    {
        STRAIGHT,
        LEFT,
        RIGHT
    }
    public class Roads : MonoBehaviour
    {
        public RoadType type;
        public Transform pivot;
        public Vector2 offset;
        public Vector2 direction;

        public Transform startPoint;
        public Transform edge;


    }
}
