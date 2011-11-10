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
        public virtual TilstandListeType ToTilstandListeType()
        {
            return new TilstandListeType()
            {
                CivilStatus = this.ToCivilStatusType(),
                LivStatus = this.ToLivStatusType(),
                LokalUdvidelse = this.ToLokalUdvidelseType()
            };
        }

        public CivilStatusType ToCivilStatusType()
        {
            return new CivilStatusType()
            {
                CivilStatusKode = Converters.ToCivilStatusKodeType(this.MaritalStatus),
                //TODO: Check if this is the mariage start or end date
                TilstandVirkning = TilstandVirkningType.Create(Converters.ToDateTime(this.MaritalStatusTimestamp, this.MaritalStatusTimestampUncertainty))
            };
        }

        public LivStatusType ToLivStatusType()
        {
            return new LivStatusType()
                {
                    LivStatusKode = Converters.ToLivStatusKodeType(this.CitizenStatusCode, Converters.ToDateTime(this.Birthdate, this.BirthdateUncertainty).HasValue),
                    //TODO: Ensure the dates are correct
                    TilstandVirkning = TilstandVirkningType.Create(Converters.ToDateTime(this.CitizenStatusTimestamp, this.CitizenStatusTimestampUncertainty))
                };
        }

    }
}