namespace PropertyBasedTesting.Domain
{
    public class PostalServiceWithBug
    {
        public bool IsFreeShipment(Parcel parcel)
        {
            return parcel.TotalPrice >= 10;
        }

        public bool IsFreeShipment(decimal parcelPrice)
        {
            return parcelPrice >= 20;
        }
    }
}