using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>();

        Square square = new Square();
        square.Color = "Red";
        square.Side = 9;

        Rectangle rectangle = new Rectangle();
        rectangle.Color = "White";
        rectangle.Length = 9;
        rectangle.Width = 3;

        Circle circle = new Circle();
        circle.Color = "Black";
        circle.Radius = 5;

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape s in shapes)
        {
            DisplayArea(s);
        }
    }

    static void DisplayArea(Shape s)
    {
        Console.WriteLine($"{s.Color} has an area of: {s.GetArea()}");
    }
}