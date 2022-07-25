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
        public void GivenTheRequirementToCreateSomeSpecificFakeListings_CreateFakeListings_ReturnsSomeListings(
            int numberOfListings,
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

        [Fact]
        public void GivenTheRequirementToCreateSomeFakeListings_CreateFakeListings_ReturnsSomeListings()
        {
            // Arrange & Act.
            var listings = FakeListings.CreateFakeListings().ToList();

            // Assert.
            listings.Count.ShouldBe(80);
            listings.GetRange(0, 20).ShouldAllBe(listing => listing is ResidentialListing);
            listings.GetRange(20, 20).ShouldAllBe(listing => listing is RentalListing);
            listings.GetRange(40, 20).ShouldAllBe(listing => listing is LandListing);
            listings.GetRange(60, 20).ShouldAllBe(listing => listing is RuralListing);
        }
    }
}
