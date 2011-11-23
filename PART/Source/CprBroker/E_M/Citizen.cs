﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas;
using CprBroker.Schemas.Part;

namespace CprBroker.Providers.E_M
{
    public partial class Citizen
    {

        public RegistreringType1 ToRegistreringType1(DateTime effectDate, Func<string, Guid> cpr2uuidFunc)
        {
            var ret = new RegistreringType1()
            {
                AktoerRef = UnikIdType.Create(E_MDataProvider.ActorId),
                AttributListe = this.ToAttributListeType(effectDate),
                CommentText = null,
                LivscyklusKode = LivscyklusKodeType.Rettet,
                RelationListe = this.ToRelationListeType(cpr2uuidFunc),
                Tidspunkt = this.ToTidspunktType(),
                TilstandListe = this.ToTilstandListeType(),
                Virkning = null
            };
            ret.CalculateVirkning();
            return ret;
        }

        public virtual AttributListeType ToAttributListeType(DateTime effectDate)
        {
            return new AttributListeType()
            {
                Egenskab = new EgenskabType[] { this.ToEgenskabType() },
                LokalUdvidelse = this.ToLokalUdvidelseType(),
                RegisterOplysning = new RegisterOplysningType[] { this.ToRegisterOplysningType(effectDate) },
                SundhedOplysning = new SundhedOplysningType[] { this.ToSundhedOplysningType() }
            };
        }

        public virtual EgenskabType ToEgenskabType()
        {
            var ret = new EgenskabType()
            {
                AndreAdresser = this.ToAndreAdresse(),
                BirthDate = this.ToBirthdate(),
                FoedestedNavn = Converters.ToNeutralString(this.BirthPlaceText),
                FoedselsregistreringMyndighedNavn = ToBirthRegistrationAuthority(),
                KontaktKanal = this.ToKontaktKanalType(),
                NaermestePaaroerende = this.ToNextOfKin(),
                NavnStruktur = this.ToNavnStrukturType(),
                PersonGenderCode = Converters.ToPersonGenderCodeType(this.Gender),
                Virkning = this.ToEgenskabTypeVirkning()
            };
            return ret;
        }

        public virtual VirkningType ToEgenskabTypeVirkning()
        {
            return VirkningType.Create(
               Converters.GetMaxDate(
                    this.ToBirthdate(),
                    Converters.ToDateTime(this.AddressingNameDate, this.AddressingNameDateUncertainty)
               ),
               null
           );
        }

        public virtual NavnStrukturType ToNavnStrukturType()
        {
            var addressingName = Converters.ToNeutralString(this.AddressingName);
            var ret = NavnStrukturType.Create(addressingName);
            ret.PersonNameForAddressingName = addressingName;
            return ret;
        }

        public virtual RegisterOplysningType ToRegisterOplysningType(DateTime effectDate)
        {
            var ret = new RegisterOplysningType()
            {
                Item = null,
                Virkning = null,
            };

            if (Constants.UnknownCountryCodes.Contains(this.CountryCode))
            {
                ret.Item = this.ToUkendtBorgerType();
                ret.Virkning = this.ToUkendtBorgerTypeVirkning();
            }
            else if (this.CountryCode == Constants.DenmarkCountryCode)
            {
                ret.Item = this.ToCprBorgerType(effectDate);
                ret.Virkning = this.ToCprBorgerTypeVirkning();
            }
            else
            {
                ret.Item = this.ToUdenlandskBorgerType();
                ret.Virkning = this.ToUdenlandskBorgerTypeVirkning();
            }
            return ret;
        }

        public CprBorgerType ToCprBorgerType(DateTime effectDate)
        {
            return new CprBorgerType()
            {
                // Not supported
                AdresseNoteTekst = null,
                // Set church membership
                FolkekirkeMedlemIndikator = this.ToChurchMembershipIndicator(),
                // Set address
                FolkeregisterAdresse = this.ToAdresseType(),
                // Set address indicator
                ForskerBeskyttelseIndikator = this.ToDirectoryProtectionIndicator(effectDate),
                // Set ddress protection indicator
                NavneAdresseBeskyttelseIndikator = this.ToAddressProtectionIndicator(effectDate),
                // Set CPR number
                PersonCivilRegistrationIdentifier = Converters.ToCprNumber(this.PNR),
                // Set nationality (always Danish in this case)
                PersonNationalityCode = this.ToCountryIdentificationCodeType(),
                // Set CPR number validity
                PersonNummerGyldighedStatusIndikator = this.ToCivilRegistrationValidityStatusIndicator(),
                // Telphone numbers are not supported
                TelefonNummerBeskyttelseIndikator = false
            };
        }

        public VirkningType ToCprBorgerTypeVirkning()
        {
            return VirkningType.Create(
               Converters.GetMaxDate(
                    Converters.ToDateTime(this.ChurchMarkerDate, this.ChurchMarkerDateUncertainty),
                    Converters.ToDateTime(this.MunicipalityArrivalDate, this.MunicipalityArrivalDateUncertainty),
                    Converters.ToDateTime(this.DepartureTimestamp, this.DepartureTimestampUncertainty),
                    Converters.ToDateTime(this.RelocationTimestamp, this.RelocationTimestampUncertainty),
                    Converters.ToDateTime(this.DirectoryProtectionDate, this.DirectoryProtectionDateUncertainty),
                    Converters.ToDateTime(this.DirectoryProtectionEndDate, this.DirectoryProtectionEndDateUncertainty),
                    Converters.ToDateTime(this.AddressProtectionDate, this.AddressProtectionDateUncertainty),
                    Converters.ToDateTime(this.AddressProtectionEndDate, this.AddressProtectionEndDateUncertainty),
                    Converters.ToDateTime(this.NationalityChangeTimestamp, this.NationalityChangeTimestampUncertainty),
                    Converters.ToDateTime(this.NationalityTerminationTimestamp, this.NationalityTerminationTimestampUncertainty),
                    Converters.ToDateTime(this.PNRCreationDate, this.PNRCreationdateUncertainty)
               ),
               null
           );
        }

        public UdenlandskBorgerType ToUdenlandskBorgerType()
        {
            return new UdenlandskBorgerType()
            {
                // Birth nationality cannot be retrieved
                FoedselslandKode = null,
                // Set to PNR
                PersonCivilRegistrationReplacementIdentifier = Converters.ToCprNumber(this.PNR),
                // Not supported
                PersonIdentifikator = null,
                // Set to current nationality
                PersonNationalityCode = new CountryIdentificationCodeType[] { this.ToCountryIdentificationCodeType() },
                // Languages are not supported
                SprogKode = null
            };
        }

        public VirkningType ToUdenlandskBorgerTypeVirkning()
        {
            return VirkningType.Create(
                Converters.GetMaxDate(
                    Converters.ToDateTime(this.PNRCreationDate, this.PNRCreationdateUncertainty),
                    Converters.ToDateTime(this.NationalityChangeTimestamp, this.NationalityChangeTimestampUncertainty),
                    Converters.ToDateTime(this.NationalityTerminationTimestamp, this.NationalityTerminationTimestampUncertainty)
                ),
                null
            );
        }

        public UkendtBorgerType ToUkendtBorgerType()
        {
            return new UkendtBorgerType()
            {
                // Set to PNR
                PersonCivilRegistrationReplacementIdentifier = Converters.ToCprNumber(this.PNR)
            };
        }

        public VirkningType ToUkendtBorgerTypeVirkning()
        {
            return VirkningType.Create(
                Converters.GetMaxDate(
                    Converters.ToDateTime(this.PNRCreationDate, this.PNRCreationdateUncertainty)
                ),
                null
            );
        }

        public virtual TidspunktType ToTidspunktType()
        {
            return TidspunktType.Create(
                Converters.GetMaxDate(
                    Converters.ToDateTime(this.BirthRegistrationDate, this.BirthRegistrationDateUncertainty),
                    this.CprChurchTimestamp,
                    this.CprPersonTimestamp,
                    Converters.ToDateTime(this.PNRMarkingDate, this.PNRMarkingDateUncertainty),
                    Converters.ToDateTime(this.MunicipalityArrivalDate, MunicipalityArrivalDateUncertainty)
                )
            );
        }

    }
}
