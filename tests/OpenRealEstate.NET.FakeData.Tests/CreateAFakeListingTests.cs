using System;
using OpenRealEstate.NET.Core;
using OpenRealEstate.NET.Core.Land;
using OpenRealEstate.NET.Core.Rental;
using OpenRealEstate.NET.Core.Residential;
using OpenRealEstate.NET.Core.Rural;
using Shouldly;
using Xunit;

namespace OpenRealEstate.NET.FakeData.Tests
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
    }
}