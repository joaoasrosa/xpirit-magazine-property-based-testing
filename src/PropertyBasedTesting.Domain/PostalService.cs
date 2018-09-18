namespace PropertyBasedTesting.Domain
{
    public class PostalService
    {
        public bool IsFreeShipment(Parcel parcel)
        {
            return parcel.TotalPrice >= 20;
        }

        public bool IsFreeShipment(decimal parcelPrice)
        {
            return parcelPrice >= 20;
        }
    }
}