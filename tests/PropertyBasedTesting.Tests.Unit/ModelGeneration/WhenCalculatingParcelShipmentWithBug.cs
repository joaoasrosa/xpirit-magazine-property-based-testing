using System.Linq;
using FsCheck;
using FsCheck.Xunit;
using PropertyBasedTesting.Domain;
using Xunit;

namespace PropertyBasedTesting.Tests.Unit.ModelGeneration
{
    public class WhenCalculatingParcelShipmentWithBug
    {
        [Property(Arbitrary = new[] {typeof(ParcelPriceBelow20Euros)}, Replay = "610985339,296499972")]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree(Parcel parcel)
        {
            var postalService = new PostalServiceWithBug();
            var isFreeShipment = postalService.IsFreeShipment(parcel);
            
            Assert.Equal(false, isFreeShipment);
        }

        [Property(Arbitrary = new[] {typeof(ParcelPriceEqualOrAbove20Euros)})]
        public void GivenParcelPriceIsEqualOrAbove20Euros_ParcelShipmentFree(Parcel parcel)
        {
            var postalService = new PostalServiceWithBug();
            var isFreeShipment = postalService.IsFreeShipment(parcel);
            
            Assert.Equal(true, isFreeShipment);
        }

        [Fact]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree_Unit()
        {
            var parcel = new Parcel(
                new[]
                {
                    new Item(9)
                }
            );
            var postalService = new PostalServiceWithBug();
            var isFreeShipment = postalService.IsFreeShipment(parcel);
            
            Assert.Equal(false, isFreeShipment);
        }

        public class ParcelPriceBelow20Euros
        {
            public static Arbitrary<Parcel> Parcel()
            {
                var input = from prices in Arb.Generate<double[]>()
                    where prices.Sum() > 0 && prices.Sum() < 20
                    select new Parcel(prices.Select(x => new Item(x)).ToArray());

                return input.ToArbitrary();
            }
        }

        public class ParcelPriceEqualOrAbove20Euros
        {
            public static Arbitrary<Parcel> Parcel()
            {
                var input = from prices in Arb.Generate<double[]>()
                    where prices.Sum() >= 20
                    select new Parcel(prices.Select(x => new Item(x)).ToArray());

                return input.ToArbitrary();
            }
        }
    }
}