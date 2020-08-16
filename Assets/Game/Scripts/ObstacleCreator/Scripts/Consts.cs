namespace ColorBump
{
    public static class Consts
    {
        public const int defaultGridSize = 3;
    }

    public enum ObjectType
    {
        Object,
        Obstacle,
        Empty
    };

    public enum ObstacleType 
    { 
        Cube, 
        Sphere, 
        Cyclinder, 
        Prism 
    }
}