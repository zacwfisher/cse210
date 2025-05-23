namespace Learning03
{
    public class Fraction
    {
        private int _top;
        private int _bottom;

        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        public Fraction(int top)
        {
            _top = top;
            _bottom = 1;
        }

        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        public int GetTop()
        {
            return _top;
        }

        public void SetTop(int top)
        {
            _top = top;
        }

        public int GetBottom()
        {
            return _bottom;
        }

        public void SetBottom(int bottom)
        {
            if (bottom != 0)
            {
                _bottom = bottom;
            }
            else
            {
                Console.WriteLine("Error: Denominator cannot be zero. Setting to 1.");
                _bottom = 1;
            }
        }

        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }

        public double GetDecimalValue()
        {
            return (double)_top / (double)_bottom;
        }
    }
}