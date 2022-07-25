namespace OpenRealEstate.FakeData.Tests
{
    public class CreateListingsTests : TestHelperUtilities
    {
        private readonly Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public virtual int Next(int min, int max)
        {
            return rnd.Next(min, max);
        }

        [Theory]
        [InlineData(typeof(ResidentialListing))]
        [InlineData(typeof(RentalListing))]
        [InlineData(typeof(LandListing))]
        [InlineData(typeof(RuralListing))]
        public void GivenThatWeNeedASomeListings_CreateFakeListings_ReturnsASomeListings(Type type)
        {
            // Arrange.
            const int numberOfListings = 3000;

            // Act.
            var listings = CreateListings(type, numberOfListings);

            // Assert.
            listings.ShouldNotBeNull();
            listings.Count.ShouldBe(numberOfListings);
            listings.ShouldAllBe(listing => listing.GetType() == type);

            // Make sure all our statuses exist.
            listings.ShouldAllBe(listing => listing.StatusType != Core.StatusType.Unknown);
            listings.ShouldAllBe(listing => !string.IsNullOrWhiteSpace(listing.SourceStatus));
        }
    }
}
