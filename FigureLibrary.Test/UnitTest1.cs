using FluentAssertions;

namespace FigureLibrary.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Circle_is_created()
        {
            var circle = new Circle(10d);
            circle.Radius.Should().Be(10d);
        }

        [Fact]
        public void Triangle_is_created()
        {
            var triangle = new Triangle(11d,
                                        20d,
                                        30d);

            triangle.A.Should().Be(11d);
            triangle.B.Should().Be(20d);
            triangle.C.Should().Be(30d);
        }

        [Fact]
        public void Square_is_created()
        {
            var square = new Square(10d);
            square.Side.Should().Be(10d);
        }

        [Theory]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.NaN)]
        [InlineData(-10d)]
        [InlineData(0)]
        public void Square_with_incorrect_Side_is_rejected(double side)
        {
            FluentActions.Invoking(() => new Square(side))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.NaN)]
        [InlineData(-10d)]
        [InlineData(0)]
        public void Circle_with_incorrect_radius_is_rejected(double radius)
        {
            FluentActions.Invoking(() => new Circle(radius))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }


        [Theory]
        [InlineData(-1d,1d,1d)]
        [InlineData(1d, -1d, 1d)]
        [InlineData(1d, 1d, -1d)]
        [InlineData(0, 1d, 1d)]
        [InlineData(1d, 0, 1d)]
        [InlineData(1d, 1d, 0)]
        [InlineData(double.NaN, 1d, 1d)]
        [InlineData(1d, double.NaN, 1d)]
        [InlineData(1d, 1d, double.NaN)]
        [InlineData(double.PositiveInfinity, 1d, 1d)]
        [InlineData(1d, double.PositiveInfinity, 1d)]
        [InlineData(1d, 1d, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, 1d, 1d)]
        [InlineData(1d, double.NegativeInfinity, 1d)]
        [InlineData(1d, 1d, double.NegativeInfinity)]
        public void Triangle_with_incorrect_sides_is_rejected(double a, double b, double c)
        {
            FluentActions.Invoking(() => new Triangle(a,b,c))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1d, 2d, 4d)]
        [InlineData(4d, 1d, 2d)]
        [InlineData(1d, 2d, 3d)]
        public void Triangle_which_not_exists_is_reject(double a, double b, double c)
        {
            FluentActions.Invoking(() => new Triangle(a, b, c))
               .Should()
               .Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Circle_area_is_calculated()
        {
            var circle = new Circle(10d);
            circle.Area.Should().BeApproximately(314.159265358979d, 0.000000000001d);
        }
        [Fact]
        public void Triangle_area_is_calculated()
        {
            var triangle = new Triangle(11d, 20d, 30d);
            triangle.Area.Should().BeApproximately(55.8788, 0.001);
        }
        [Fact]
        public void Square_area_is_calculated()
        {
            var square = new Square(10d);
            square.Area.Should().BeApproximately(100d, 1d);
        }
        [Fact]
        public void Circle_and_triangle_are_shapes()
        {
            var circle = new Circle(10d);
            var triangle = new Triangle(10d, 21d, 30d);
            circle.Should().BeAssignableTo<IShape>();
            triangle.Should().BeAssignableTo<IShape>();
        }
        [Fact]
        public void Square_is_shape()
        {
            var square = new Square(10d);
            square.Should().BeAssignableTo<IShape>();
        } 

        [Fact]
        public void Triangle_is_right()
        {
            var triangle = new Triangle(3d, 4d, 5d);
            triangle.IsRight.Should().BeTrue();
        }
    }

}