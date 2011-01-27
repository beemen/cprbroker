﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CprBroker.Schemas.Part
{
    public partial class VirkningType
    {
        public static VirkningType Create(DateTime? fromDate, DateTime? toDate)
        {
            return new VirkningType()
            {
                //TODO: Fill actor text
                AktoerTekst = null,
                //TODO: Fill comment text
                CommentText = null,
                FraTidspunkt = TidspunktType.Create(fromDate),                
                TilTidspunkt = TidspunktType.Create(toDate)
            };
        }
    }
}
