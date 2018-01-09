using FizzWare.NBuilder;
using FizzWare.NBuilder.Generators;
using OpenRealEstate.NET.Core;
using System;

namespace OpenRealEstate.NET.FakeData
{
    public class FakeCommunication
    {
        public static Communication CreateAFakeCommunication(CommunicationType? communicationType = CommunicationType.Mobile)
        {
            if (communicationType == null ||
                communicationType == CommunicationType.Unknown)
            {
                var index = GetRandom.Int(1, Enum.GetValues(typeof(CommunicationType)).Length - 1);
                communicationType = (CommunicationType)Enum.GetValues(typeof(CommunicationType))
                                                           .GetValue(index);
            }

            return Builder<Communication>.CreateNew()
                                         .With(x => x.CommunicationType, communicationType.Value)
                                         .Build();
        }
    }
}
