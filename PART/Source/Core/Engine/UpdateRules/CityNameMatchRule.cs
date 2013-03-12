﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas.Part;
using CprBroker.Data.Part;

namespace CprBroker.Engine.UpdateRules
{
    public class CityNameMatchRule : MatchRule<DanskAdresseType>
    {
        public override DanskAdresseType GetObject(RegistreringType1 oio)
        {
            if (
                oio.AttributListe != null
                && oio.AttributListe.RegisterOplysning != null
                && oio.AttributListe.RegisterOplysning.Length == 1
                && oio.AttributListe.RegisterOplysning[0] != null
                && oio.AttributListe.RegisterOplysning[0].Item is CprBorgerType
                && (oio.AttributListe.RegisterOplysning[0].Item as CprBorgerType).FolkeregisterAdresse != null
                )
            {
                var cprBorger = oio.AttributListe.RegisterOplysning[0].Item as CprBorgerType;
                if (cprBorger != null && cprBorger.FolkeregisterAdresse != null)
                    return cprBorger.FolkeregisterAdresse.Item as DanskAdresseType;
            }
            return null;
        }

        public override bool AreCandidates(DanskAdresseType existingObj, DanskAdresseType newObj)
        {
            return

                string.Equals(existingObj.PostDistriktTekst, newObj.PostDistriktTekst)

                && existingObj.AddressComplete != null && existingObj.AddressComplete.AddressPostal != null
                && newObj.AddressComplete != null && newObj.AddressComplete.AddressPostal != null

                && string.Equals(existingObj.PostDistriktTekst, newObj.PostDistriktTekst)
                && string.Equals(existingObj.AddressComplete.AddressPostal.PostCodeIdentifier, newObj.AddressComplete.AddressPostal.PostCodeIdentifier)
                && string.IsNullOrEmpty(existingObj.AddressComplete.AddressPostal.DistrictSubdivisionIdentifier);
        }

        public override void UpdateOioFromXmlType(DanskAdresseType existingObj, DanskAdresseType newObj)
        {
            existingObj.AddressComplete.AddressPostal.DistrictName = newObj.AddressComplete.AddressPostal.DistrictName;
            existingObj.AddressComplete.AddressPostal.DistrictSubdivisionIdentifier = newObj.AddressComplete.AddressPostal.DistrictSubdivisionIdentifier;
        }

        public override void UpdateDbFromXmlType(PersonRegistration dbReg, DanskAdresseType newObj)
        {
            dbReg.PersonAttributes.Where(pa => pa.CprData != null).First().CprData.Address.DenmarkAddress.DistrictName = newObj.AddressComplete.AddressPostal.DistrictName;
            dbReg.PersonAttributes.Where(pa => pa.CprData != null).First().CprData.Address.DenmarkAddress.DistrictSubdivisionIdentifier = newObj.AddressComplete.AddressPostal.DistrictSubdivisionIdentifier;
        }
    }
}