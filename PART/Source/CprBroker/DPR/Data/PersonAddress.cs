﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The CPR Broker concept was initally developed by
 * Gentofte Kommune / Municipality of Gentofte, Denmark.
 * Contributor(s):
 * Steen Deth
 *
 *
 * The Initial Code for CPR Broker and related components is made in
 * cooperation between Magenta, Gentofte Kommune and IT- og Telestyrelsen /
 * Danish National IT and Telecom Agency
 *
 * Contributor(s):
 * Beemen Beshara
 *
 * The code is currently governed by IT- og Telestyrelsen / Danish National
 * IT and Telecom Agency
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas;
using CprBroker.Schemas.Part;
using CprBroker.Utilities;

namespace CprBroker.Providers.DPR
{
    public partial class PersonAddress : IAddressSource
    {
        public AdresseType ToAdresseType(PersonTotal personTotal)
        {
            string postDistrict = personTotal.PostDistrictName;

            var greenlandicAddress = this.MunicipalityCode >= AddressConstants.GreenlandMunicipalCodeStart;

            return new AdresseType()
            {
                Item = greenlandicAddress ? (AdresseBaseType) ToGroenlandAdresseType(postDistrict) : ToDanskAdresseType(postDistrict)
            };
        }

        public DanskAdresseType ToDanskAdresseType(string postDistrict)
        {
            return new DanskAdresseType()
            {
                AddressComplete = ToAddressCompleteType(postDistrict),
                // No address point
                AddressPoint = null,
                NoteTekst = ToAddressNoteTekste(),
                PolitiDistriktTekst = null,
                PostDistriktTekst = postDistrict,
                SkoleDistriktTekst = null,
                SocialDistriktTekst = null,
                SogneDistriktTekst = null,
                SpecielVejkodeIndikator = ToSpecielVejkodeIndikator(),
                SpecielVejkodeIndikatorSpecified = true,
                UkendtAdresseIndikator = false,
                ValgkredsDistriktTekst = null
            };
        }

        public AddressCompleteType ToAddressCompleteType(string postDistrict)
        {
            return new CprBroker.Schemas.Part.AddressCompleteType()
            {
                AddressAccess = ToAddressAccessType(),
                AddressPostal = ToAddressPostalType(postDistrict),
            };
        }

        public AddressAccessType ToAddressAccessType()
        {
            return new CprBroker.Schemas.Part.AddressAccessType()
            {
                MunicipalityCode = MunicipalityCode.ToDecimalString(),
                StreetBuildingIdentifier = HouseNumber,
                StreetCode = StreetCode.ToDecimalString()
            };
        }

        public AddressPostalType ToAddressPostalType(string postDistrict)
        {
            return new CprBroker.Schemas.Part.AddressPostalType()
            {
                CountryIdentificationCode = ToCountryIdentificationCodeType(),
                DistrictName = postDistrict,
                DistrictSubdivisionIdentifier = Town,
                FloorIdentifier = Floor,
                MailDeliverySublocationIdentifier = null,
                PostCodeIdentifier = PostCode.ToDecimalString(),
                PostOfficeBoxIdentifier = null,
                StreetBuildingIdentifier = HouseNumber,
                StreetName = StreetAddressingName,
                StreetNameForAddressingName = StreetAddressingName,
                SuiteIdentifier = DoorNumber,
            };
        }

        public CountryIdentificationCodeType ToCountryIdentificationCodeType()
        {
            return CountryIdentificationCodeType.Create(_CountryIdentificationSchemeType.imk, Constants.DenmarkKmdCode);
        }

        public GroenlandAdresseType ToGroenlandAdresseType(string postDistrict)
        {
            return new GroenlandAdresseType()
            {
                AddressCompleteGreenland = ToAddressCompleteGreenlandType(postDistrict),
                NoteTekst = ToAddressNoteTekste(),
                SpecielVejkodeIndikator = ToSpecielVejkodeIndikator(),
                SpecielVejkodeIndikatorSpecified = true,
                UkendtAdresseIndikator = false
            };
        }

        public AddressCompleteGreenlandType ToAddressCompleteGreenlandType(string postDistrict)
        {
            return new AddressCompleteGreenlandType()
            {
                CountryIdentificationCode = ToCountryIdentificationCodeType(),

                MunicipalityCode = this.MunicipalityCode.ToDecimalString(),
                StreetCode = this.StreetCode.ToDecimalString(),
                StreetName = this.StreetAddressingName,
                StreetNameForAddressingName = this.StreetAddressingName,

                GreenlandBuildingIdentifier = this.GreenlandConstructionNumber,
                StreetBuildingIdentifier = this.HouseNumber,
                
                FloorIdentifier = this.Floor,
                SuiteIdentifier = this.DoorNumber,

                MailDeliverySublocationIdentifier = null,
                PostCodeIdentifier = this.PostCode.ToDecimalString(),
                DistrictName = postDistrict,
                DistrictSubdivisionIdentifier = Town
            };
        }

        public AdresseType ToForeignAddressFromSupplementary()
        {
            return new AdresseType()
            {
                Item = new VerdenAdresseType()
                {
                    ForeignAddressStructure = new ForeignAddressStructureType()
                    {
                        // TODO: shouldn't this be a foreign address?
                        CountryIdentificationCode = CountryIdentificationCodeType.Create(_CountryIdentificationSchemeType.imk, Constants.DenmarkKmdCode),
                        LocationDescriptionText = Location,
                        PostalAddressFirstLineText = AdditionalAddressLine1,
                        PostalAddressSecondLineText = AdditionalAddressLine2,
                        PostalAddressThirdLineText = AdditionalAddressLine3,
                        PostalAddressFourthLineText = AdditionalAddressLine4,
                        PostalAddressFifthLineText = AdditionalAddressLine5,
                    },
                    NoteTekst = ToAddressNoteTekste(),
                    UkendtAdresseIndikator = false
                }
            };
        }

        public bool ToSpecielVejkodeIndikator()
        {
            return Schemas.Util.Converters.ToSpecielVejkodeIndikator(this.StreetCode);
        }


        public string ToAddressNoteTekste()
        {
            return null;
        }

        public AdresseType ToAdresseType()
        {
            return this.ToAdresseType(this.PersonTotal);
        }

        public IRegistrationInfo Registration
        {
            get { throw new NotImplementedException(); }
        }

        public DataTypeTags Tag
        {
            get { return DataTypeTags.Address; }
        }

        public DateTime? ToEndTS()
        {
            return Utilities.DateFromDecimal(this.AddressEndDate);
        }

        public bool ToEndTSCertainty()
        {
            return true;
        }

        public DateTime? ToStartTS()
        {
            return Utilities.DateFromDecimal(this.AddressStartDate);
        }

        public bool ToStartTSCertainty()
        {
            return this.AddressStartDateMarker == null;
        }
    }
}
