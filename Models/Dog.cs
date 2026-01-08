namespace DogBoarding.Models
{
    class Dog
    {
        #region Properties

        public string OwnerName {get; set;}
        public string DogName {get; set;}
        public double DogWeight {get; set;}

        #endregion

        #region Constructor

        public Dog(string ownerName, string dogName, double dogWeight)
        {
            OwnerName = ownerName;
            DogName = dogName;
            DogWeight = dogWeight;
        }



        #endregion
    }
}