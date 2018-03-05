using OpenRealEstate.Core;
using OpenRealEstate.Core.Residential;
using Shouldly;
using System.Linq;
using Xunit;

namespace OpenRealEstate.FakeData.Tests
{
    public class CreateFakeListingsTests
    {
        [Theory]
        [InlineData(20, 10, 3, 7)]
        [InlineData(5, 5, 0, 0)]
        [InlineData(10, 10, 0, 0)]
        [InlineData(11, 10, 1, 0)]
        [InlineData(13, 10, 3, 0)]
        [InlineData(14, 10, 3, 1)]
        [InlineData(17, 10, 3, 4)]
        [InlineData(21, 10, 3, 7)] // #21 is not included.
        [InlineData(50, 10, 3, 7)] // #50 is not included.
        public void GivenTheRequirementToCreateSomeFakeListings_CreateFakeListings_ReturnsSomeListings(int numberOfListings,
                                                                                                       int numberOfActive,
                                                                                                       int numberOfSold,
                                                                                                       int numberOfRemoved)
        {
            // Arrange
            const int defaultNumberOfFixedListings = 20;

            //Act.
            var listings = FakeListings.CreateFakeListings<ResidentialListing>(numberOfListings)
                                       .Take(defaultNumberOfFixedListings)
                                       .ToArray();

            // Assert.
            if (numberOfListings > defaultNumberOfFixedListings)
            {
                listings.Length.ShouldBe(defaultNumberOfFixedListings);
            }
            else
            {
                listings.Length.ShouldBe(numberOfListings);
            }
            
            listings.Count(x => x.StatusType == StatusType.Available).ShouldBe(numberOfActive);
            listings.Count(x => x.StatusType == StatusType.Sold).ShouldBe(numberOfSold);
            listings.Count(x => x.StatusType == StatusType.Leased).ShouldBe(0); // Can never have a leased residential listing.
            listings.Count(x => x.StatusType == StatusType.Removed).ShouldBe(numberOfRemoved);
        }
    }
}
