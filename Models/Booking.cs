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

        public bool Confirm()
        {
            if(Status != BookingStatus.Requested)
            {
                return false;
            }

            Status = BookingStatus.Confirmed;
            return true;
        }

        public bool MarkAsPaid()
        {   
            if(Status != BookingStatus.Confirmed)
            {
                return false;
            }

            Status = BookingStatus.Paid;
            return true;
        }

        public bool Cancel()
        {
            if(Status == BookingStatus.Paid)
            {
                return false;
            }

            Status = BookingStatus.Cancelled;
            return true;
        }

        public void ForceStatus(BookingStatus newStatus)
        {
            if(!Enum.IsDefined(typeof(BookingStatus), newStatus))
            {
                throw new ArgumentException("Invalid booking status");
            }

            Status = newStatus;
        }

        #endregion
        
    }
}
    
