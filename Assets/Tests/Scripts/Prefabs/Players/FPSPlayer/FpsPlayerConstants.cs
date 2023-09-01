namespace Tests.Scripts.Prefabs.Players.FPSPlayer
{
    public abstract class FpsPlayerConstants
    {
        public abstract class Fov
        {
            public const float Min = 1.0f;
            public const float Max = 360.0f;
            public const float Default = 90.0f;
        }
        
        public abstract class Interactions
        {
            public const float MinInteractionDistance = 0.0f;
            public const float MaxInteractionDistance = 10.0f;
            public const float DefaultInteractionDistance = 1.5f;
        }
    }
}