namespace HW_4_Repka
{
    internal class Plant
    {
        private int _daysOfGrow;
        private const float _kgPerDay = 0.5f;

        public string? Name { get; }
        public float Weigth { get; }

        public Plant(string name, int days)
        {
            Name = name;
            _daysOfGrow = days;
            Weigth = _daysOfGrow * _kgPerDay;
        }
    }
}
