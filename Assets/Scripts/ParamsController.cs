using UnityEngine;

public class ParamsController : MonoBehaviour
{
    public static class PlayerInputData
    {
        public const float DISTANCE_SENSITIVITY = 10f;
    }

    public static class PlayerMovingData
    {
        public const int SPEED = 5;
        public const float INCREASED_SPEED_FACTOR = 2f;
    }

    public static class PlayerShowingData
    {
        public const float MAX_SIZE = 3;
    }

    public static class Gravity
    {
        public const int GRAVITY_FORCE_FACTOR = 20;
        public const int SIDE_FORCE = 60;
    }
}