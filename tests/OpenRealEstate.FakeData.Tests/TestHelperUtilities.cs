namespace OpenRealEstate.FakeData.Tests
{
    public abstract class TestHelperUtilities
    {
        protected IList<Listing> CreateListings(Type listingType,
                                                int numberOfFakeListings)
        {
            if (listingType == typeof(ResidentialListing))
            {
                return FakeListings.CreateFakeListings<ResidentialListing>(numberOfFakeListings)
                                   .Cast<Listing>()
                                   .ToList();
            }

            if (listingType == typeof(RentalListing))
            {
                return FakeListings.CreateFakeListings<RentalListing>(numberOfFakeListings)
                                   .Cast<Listing>()
                                   .ToList();
            }

            if (listingType == typeof(LandListing))
            {
                return FakeListings.CreateFakeListings<LandListing>(numberOfFakeListings)
                                   .Cast<Listing>()
                                   .ToList();
            }

            if (listingType == typeof(RuralListing))
            {
                return FakeListings.CreateFakeListings<RuralListing>(numberOfFakeListings)
                                   .Cast<Listing>()
                                   .ToList();
            }

            throw new Exception($"Failed to assert the suggested type: '{listingType}'.");
        }
    }
}
