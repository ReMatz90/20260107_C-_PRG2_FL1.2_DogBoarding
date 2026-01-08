using System;
using DogBoarding.Enums;

namespace DogBoarding.Models
{
    class Booking
    {
        #region Properties

        public Dog Dog { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BookingStatus Status { get; private set; }

        #endregion

        #region Constructor

        public Booking(Dog dog, DateTime startDate, DateTime endDate)
        {
            Dog = dog;
            StartDate = startDate;
            EndDate = endDate;

            Status = BookingStatus.Requested;
        }

        #endregion

        #region Calculated Properties

        public int DaysBooked
        {
            get
            {
                return (EndDate - StartDate).Days +1;
            }
            
        }

        #endregion

        #region Status Transitions

        public void Confirm()
        {
            if(Status != BookingStatus.Requested)
            {
                return;
            }

            Status = BookingStatus.Confirmed;
        }

        public void MarkAsPaid()
        {
            if(Status != BookingStatus.Confirmed)
            {
                return;
            }

            Status = BookingStatus.Paid;
        }

        public void Cancel()
        {
            if(Status == BookingStatus.Paid)
            {
                return;
            }

            Status = BookingStatus.Cancelled;
        }

        #endregion
        
    }
}
    
