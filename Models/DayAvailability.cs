using System;

namespace DogBoarding.Models
{
    class DayAvailability
    {
        public DateTime Date { get; }
        public int BookedDogs { get; private set; }
        public int MaxDogs { get; }

        public DayAvailability(DateTime date, int maxDogs)
        {
            Date = date.Date;
            MaxDogs = maxDogs;
            BookedDogs = 0;
        }

        public bool CanAcceptAnotherDog()
        {
            return BookedDogs < MaxDogs;
        }

        public void AddDog()
        {
            if (!CanAcceptAnotherDog())
            {
                throw new InvalidOperationException("Daily capacity exceeded.");
            }

            BookedDogs++;
        }
    }
}
