namespace ColorBump
{
    public static class Consts
    {
        public const int defaultGridSize = 3;
    }

    public enum ObjectType
    {
        Normal,
        Obstacle,
        Empty
    };

    public enum ObstacleType 
    { 
        Cube = 0, 
        Cube_S = 1,
        Cube_L = 2,
        Sphere = 5, 
        Sphere_S = 6,
        Cyclinder = 10,
        Cyclinder_S = 11,
        Prism = 15,
        Bar = 20,
        Arch = 25,
        Pipe = 30
    }
}