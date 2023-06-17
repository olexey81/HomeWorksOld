namespace HW_4_Repka
{
    internal class Charachter
    {
        private int _charachtersCounter;
        public string? Name { get; }
        public float Force { get; }

        public Charachter(int index = 0, float prevForce = 0)
        {
            Name = Enum.GetName(typeof(CharachtersNames), index);
            _charachtersCounter = ++index;
            Force = prevForce + 20f / _charachtersCounter  - _charachtersCounter / 2f;  //сила кожного наступного об'єкта є сумарною з попередніми, формула - "емпірична" 
        }

        public bool IsPulledPlant(Plant plant)
        {
            if (Force > plant.Weigth)
            {
                Console.WriteLine($"І {plant.Name} вийшла з під землі!");
                return true;
            }
            else
                return false;
        }

        public Charachter CallHelp() => new Charachter(_charachtersCounter, Force);


    }
}
