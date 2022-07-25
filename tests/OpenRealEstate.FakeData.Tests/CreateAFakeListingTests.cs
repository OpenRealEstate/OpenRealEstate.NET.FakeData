namespace OpenRealEstate.FakeData.Tests
{
    public class CreateAFakeListingTests
    {
        [Theory]
        [InlineData(typeof(ResidentialListing))]
        [InlineData(typeof(RentalListing))]
        [InlineData(typeof(LandListing))]
        [InlineData(typeof(RuralListing))]
        public void GivenThatWeNeedAListing_CreateAFakeListing_ReturnsAListing(Type type)
        {
            // Arrange & Act.
            var listing = type == typeof(ResidentialListing)
                              ? FakeListings.CreateAFakeListing<ResidentialListing>()
                              : type == typeof(RentalListing)
                                  ? FakeListings.CreateAFakeListing<RentalListing>()
                                  : type == typeof(LandListing)
                                      ? FakeListings.CreateAFakeListing<LandListing>()
                                      : (Listing) FakeListings.CreateAFakeListing<RuralListing>();

            // Assert.
            listing.ShouldNotBeNull();
            listing.GetType().ShouldBe(type);
        }

        [Theory]
        [InlineData(typeof(ResidentialListing))]
        [InlineData(typeof(RentalListing))]
        [InlineData(typeof(LandListing))]
        [InlineData(typeof(RuralListing))]
        public void GivenASpecificListingWithAllUtcDates_CreateAFakeListing_HasAllUtcDates(Type type)
        {
            // Arrange & Act.
            var listing = type == typeof(ResidentialListing)
                              ? FakeListings.CreateAFakeListing<ResidentialListing>()
                              : type == typeof(RentalListing)
                                  ? FakeListings.CreateAFakeListing<RentalListing>()
                                  : type == typeof(LandListing)
                                      ? FakeListings.CreateAFakeListing<LandListing>()
                                      : (Listing) FakeListings.CreateAFakeListing<RuralListing>();

            // Assert.
            listing.ShouldNotBeNull();
            listing.CreatedOn.Kind.ShouldBe(DateTimeKind.Utc);
            listing.UpdatedOn.Kind.ShouldBe(DateTimeKind.Utc);
            foreach (var inspection in listing.Inspections)
            {
                inspection.OpensOn.Kind.ShouldBe(DateTimeKind.Utc);
                inspection.ClosesOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
            }

            if (listing is RentalListing rentalListing)
            {
                rentalListing.AvailableOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
                if (rentalListing.Pricing.RentedOn.HasValue)
                {
                    rentalListing.Pricing.RentedOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
                }
            }

            if ((listing is ISalePricing salePricing) &&
                (salePricing.Pricing.SoldOn.HasValue))
            {
                salePricing.Pricing.SoldOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
            }

            if (listing is IAuctionOn auctionOn)
            {
                auctionOn.AuctionOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
            }

            if (listing.Images.Any())
            {
                listing.Images.ShouldAllBe(x => x.CreatedOn.Value.Kind == DateTimeKind.Utc);
            }

            if (listing.FloorPlans.Any())
            {
                listing.FloorPlans.ShouldAllBe(x => x.CreatedOn.Value.Kind == DateTimeKind.Utc);
            }

            if (listing.Documents.Any())
            {
                listing.Documents.ShouldAllBe(x => x.CreatedOn.Value.Kind == DateTimeKind.Utc);
            }
        }
    }
}
