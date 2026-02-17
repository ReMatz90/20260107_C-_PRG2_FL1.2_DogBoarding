using System;
using System.Collections.Generic;
using System.Linq;
using DogBoarding.Models;
using DogBoarding.Enums;

namespace DogBoarding.Services
{
    class AvailabilityService
    {
        private const int MaxDogsPerDay = 10;

        public List<DayAvailability> CalculateAvailability(
            List<Booking> bookings,
            DateTime from,
            DateTime to)
        {
            List<DayAvailability> days = new List<DayAvailability>();

            for (DateTime date = from.Date; date <= to.Date; date = date.AddDays(1))
            {
                days.Add(new DayAvailability(date, MaxDogsPerDay));
            }

            foreach (Booking booking in bookings)
            {
                if (booking.Status != BookingStatus.Confirmed &&
                    booking.Status != BookingStatus.Paid)
                {
                    continue;
                }

                foreach (DayAvailability day in days)
                {
                    if (day.Date >= booking.StartDate.Date &&
                        day.Date <= booking.EndDate.Date)
                    {
                        day.AddDog();
                    }
                }
            }

            return days;
        }
    }
}
