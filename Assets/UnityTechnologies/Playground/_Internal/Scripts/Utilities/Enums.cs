namespace Playground.Utilities
{
    public class Enums
    {
        public enum Axes
        {
            X,
            Y
        }

        public enum Directions
        {
            Up,
            Right,
            Down,
            Left
        }

        public enum KeyGroups
        {
            ArrowKeys,
            WASD
        }

        public enum MovementType
        {
            AllDirections = 0,
            OnlyHorizontal,
            OnlyVertical
        }

        public enum Players
        {
            Player = 0,
            Player2 = 1
        }

        public enum Targets
        {
            ThisObject,
            ObjectThatCollided
        }
    }
}