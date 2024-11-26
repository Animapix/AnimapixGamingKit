using System.Numerics;


namespace AnimapixGamingKit
{
    public class Vector
    {
        public float x;
        public float y;

        public static Vector Zero => new();
        public static Vector One => new Vector(1, 1);
        public static Vector Up => new Vector(0, -1);
        public static Vector Down => new Vector(0, 1);
        public static Vector Left => new Vector(-1, 0);
        public static Vector Right => new Vector(1, 0);

        public Vector2 Vector2 => new Vector2(x, y);

        public Vector(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }

        public static Vector operator *(Vector a, float b)
        {
            return new Vector(a.x * b, a.y * b);
        }

        public static Vector operator /(Vector a, float b)
        {
            return new Vector(a.x / b, a.y / b);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return a.x != b.x || a.y != b.y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector vector && x == vector.x && y == vector.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public Vector Normalize()
        {
            return this / Magnitude();
        }

        public float Dot(Vector other)
        {
            return x * other.x + y * other.y;
        }

        public float Cross(Vector other)
        {
            return x * other.y - y * other.x;
        }

        public float Distance(Vector other)
        {
            return (this - other).Magnitude();
        }

        public Vector Rotate(float angle)
        {
            float rad = angle * (float)Math.PI / 180;
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);
            return new Vector(x * cos - y * sin, x * sin + y * cos);
        }

        public float Angle(Vector other)
        {
            return (float)Math.Atan2(Cross(other), Dot(other)) * 180 / (float)Math.PI;
        }

        public Vector Lerp(Vector other, float t)
        {
            return this * (1 - t) + other * t;
        }

        public Vector Reflect(Vector normal)
        {
            return this - normal * 2 * Dot(normal);
        }

        public Vector Project(Vector other)
        {
            return other * (Dot(other) / other.Dot(other));
        }

        public Vector ProjectOnNormal(Vector normal)
        {
            return normal * (Dot(normal) / normal.Dot(normal));
        }

        public Vector Perpendicular()
        {
            return new Vector(-y, x);
        }

        public Vector PerpendicularClockwise()
        {
            return new Vector(y, -x);
        }

        public Vector PerpendicularCounterClockwise()
        {
            return new Vector(-y, x);
        }

        public static Vector Min(Vector a, Vector b)
        {
            return new Vector(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
        }

        public static Vector Max(Vector a, Vector b)
        {
            return new Vector(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
        }

        public static Vector Clamp(Vector value, Vector min, Vector max)
        {
            return Min(Max(value, min), max);
        }

        public static Vector MoveTowards(Vector current, Vector target, float maxDistanceDelta)
        {
            Vector a = target - current;
            float magnitude = a.Magnitude();
            if (magnitude <= maxDistanceDelta || magnitude == 0)
                return target;
            return current + a / magnitude * maxDistanceDelta;
        }
    }
}
