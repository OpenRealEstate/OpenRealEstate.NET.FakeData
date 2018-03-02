using System;
using OpenRealEstate.Core;
using OpenRealEstate.Core.Land;
using OpenRealEstate.Core.Rental;
using OpenRealEstate.Core.Residential;
using OpenRealEstate.Core.Rural;
using Shouldly;
using Xunit;

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

            if (listing is ResidentialListing residentialListing)
            {
                residentialListing.AuctionOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
            }

            if (listing is RentalListing rentalListing)
            {
                rentalListing.AvailableOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
            }

            if (listing is LandListing landListing)
            {
                landListing.AuctionOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
            }

            if (listing is RuralListing ruralListing)
            {
                ruralListing.AuctionOn.Value.Kind.ShouldBe(DateTimeKind.Utc);
            }
        }
    }
}