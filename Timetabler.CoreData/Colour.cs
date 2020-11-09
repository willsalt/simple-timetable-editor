namespace Timetabler.CoreData
{
    public struct Colour
    {
        public uint Argb { get; private set; }

        public Colour(uint argb)
        {
            Argb = argb;
        }

        public int R => (int)(Argb & 0xff0000) >> 16;

        public int G => (int)(Argb & 0xff00) >> 8;

        public int B => (int)(Argb & 0xff);

        public static Colour Black => new Colour(0xff000000);

        public static Colour White => new Colour(0xffffffff);

        public static Colour LightGrey => new Colour(0xffd3d3d3);
    }
}
