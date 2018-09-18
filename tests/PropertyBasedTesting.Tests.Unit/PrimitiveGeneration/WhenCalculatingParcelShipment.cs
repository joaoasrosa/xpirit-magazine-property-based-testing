using FsCheck;
using FsCheck.Xunit;
using PropertyBasedTesting.Domain;
using Xunit;

namespace PropertyBasedTesting.Tests.Unit.PrimitiveGeneration
{
    public class WhenCalculatingParcelShipment
    {
        [Property(Arbitrary = new[] {typeof(ParcelPriceBelow20Euros)})]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree(decimal parcelPrice)
        {
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(parcelPrice);

            Assert.Equal(false, isFreeShipment);
        }

        [Property(Arbitrary = new[] {typeof(ParcelPriceEqualOrAbove20Euros)})]
        public void GivenParcelPriceIsEqualOrAbove20Euros_ParcelShipmentFree(decimal parcelPrice)
        {
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(parcelPrice);

            Assert.Equal(true, isFreeShipment);
        }

        public class ParcelPriceBelow20Euros
        {
            public static Arbitrary<decimal> ParcelPrice() =>
                Arb.Default.Decimal().Generator.Where(x => x > 0 && x < 20).ToArbitrary();
        }

        public class ParcelPriceEqualOrAbove20Euros
        {
            public static Arbitrary<decimal> ParcelPrice() =>
                Arb.Default.Decimal().Generator.Where(x => x >= 20).ToArbitrary();
        }
    }
}