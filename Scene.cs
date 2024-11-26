namespace AnimapixGamingKit
{
    public abstract class Scene
    {
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Dispose();

        internal void Process()
        {
            Update();
            Draw();
        }
    }
}
