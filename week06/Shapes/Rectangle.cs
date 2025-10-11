public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public override double GetArea()
    {
        return Length * Width;
    }
}