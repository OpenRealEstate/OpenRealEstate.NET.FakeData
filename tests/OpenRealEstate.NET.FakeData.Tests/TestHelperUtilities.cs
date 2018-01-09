using System;
using System.Collections.Generic;
using System.Linq;
using OpenRealEstate.NET.Core;
using OpenRealEstate.NET.Core.Land;
using OpenRealEstate.NET.Core.Rental;
using OpenRealEstate.NET.Core.Residential;
using OpenRealEstate.NET.Core.Rural;

namespace OpenRealEstate.NET.FakeData.Tests
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