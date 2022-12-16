namespace ColorPickerExtraLib.Utilities
{
    using System.Windows;
    using System.Windows.Media;
    using ColorPickerExtraLib.Models;

    public class EmptyShapeGeometry
    {
        private static Point topLeft = new Point(0, 0);
        private static Point bottomLeft = new Point(0, 1);
        private static Point topRight = new Point(1, 0);
        private static Point bottomRight = new Point(1, 1);
        private static Point leftCenter = new Point(0, 0.5);
        private static Point topCenter = new Point(0.5, 0);
        private static Point rightCenter = new Point(1, 0.5);
        private static Point bottomCenter = new Point(0.5, 1);

        public static Geometry GetShapeGeometry(ShapeGeometry shapeGeometry)
        {
            Geometry newGeometry;
            switch (shapeGeometry)
            {
                case ShapeGeometry.Border:
                    newGeometry = new RectangleGeometry(new Rect(topLeft, bottomRight));
                    break;
                case ShapeGeometry.BorderedBottomLeftToTopRight:
                default:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new RectangleGeometry(new Rect(topLeft, bottomRight)),
                            new LineGeometry(bottomLeft, topRight)
                        }
                    };
                    break;
                case ShapeGeometry.BorderedTopLeftToBottomRight:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new RectangleGeometry(new Rect(topLeft, bottomRight)),
                            new LineGeometry(topLeft, bottomRight)
                        }
                    };
                    break;
                case ShapeGeometry.BorderedHorizontalLine:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new RectangleGeometry(new Rect(topLeft, bottomRight)),
                            new LineGeometry(leftCenter, rightCenter)
                        }
                    };
                    break;
                case ShapeGeometry.BorderedVerticalLine:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new RectangleGeometry(new Rect(topLeft, bottomRight)),
                            new LineGeometry(topCenter, bottomCenter)
                        }
                    };
                    break;
                case ShapeGeometry.BorderedPerpendicularCross:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new RectangleGeometry(new Rect(topLeft, bottomRight)),
                            new LineGeometry(bottomLeft, topRight),
                            new LineGeometry(topLeft, bottomRight)
                        }
                    };
                    break;
                case ShapeGeometry.BorderedParallelCross:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new RectangleGeometry(new Rect(topLeft, bottomRight)),
                            new LineGeometry(topCenter, bottomCenter),
                            new LineGeometry(leftCenter, rightCenter)
                        }
                    };
                    break;
                case ShapeGeometry.BottomLeftToTopRight:
                    newGeometry = new LineGeometry(bottomLeft, topRight);
                    break;
                case ShapeGeometry.TopLeftToBottomRight:
                    newGeometry = new LineGeometry(topLeft, bottomRight);
                    break;
                case ShapeGeometry.HorizontalLine:
                    newGeometry = new LineGeometry(leftCenter, rightCenter);
                    break;
                case ShapeGeometry.VerticalLine:
                    newGeometry = new LineGeometry(topCenter, bottomCenter);
                    break;
                case ShapeGeometry.PerpendicularCross:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new LineGeometry(bottomLeft, topRight),
                            new LineGeometry(topLeft, bottomRight)
                        }
                    };
                    break;
                case ShapeGeometry.ParallelCross:
                    newGeometry = new GeometryGroup()
                    {
                        Children = new GeometryCollection()
                        {
                            new LineGeometry(topCenter, bottomCenter),
                            new LineGeometry(leftCenter, rightCenter)
                        }
                    };
                    break;
            }

            return newGeometry;
        }
    }
}
