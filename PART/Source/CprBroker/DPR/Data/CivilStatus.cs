﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas;
using CprBroker.Schemas.Part;

namespace CprBroker.Providers.DPR
{
    public partial class CivilStatus
    {
        public PersonRelationType ToPersonRelationType(Func<decimal, Guid> cpr2uuidFunc, bool forPreviousInterval = false)
        {
            return new PersonRelationType()
            {
                ReferenceID = UnikIdType.Create(cpr2uuidFunc(SpousePNR.Value)),
                CommentText = "",
                Virkning = VirkningType.Create(
                    Utilities.DateFromDecimal(forPreviousInterval ? null : MaritalStatusDate),
                    Utilities.DateFromDecimal(forPreviousInterval ? MaritalStatusDate : MaritalEndDate)
                )
            };
        }

        public static PersonRelationType[] ToToPersonRelationTypeArray(CivilStatus[] dbCivilStates, Func<decimal, Guid> cpr2uuidFunc, char marriedStatus, char divorcedStatus, char widowStatus)
        {
            char[] maritalStates = new char[] { marriedStatus, divorcedStatus, widowStatus };

            // Filter the correct records
            dbCivilStates = dbCivilStates
                .Where(civ =>
                    maritalStates.Contains(civ.MaritalStatus.Value, new CaseInvariantCharComparer())
                    && civ.SpousePNR.HasValue
                    && civ.SpousePNR.Value > 0
                )
                .OrderBy(civ => civ.MaritalStatusDate)
                .ToArray();

            var ret = new List<PersonRelationType>();
            for (int i = 0; i < dbCivilStates.Length; i++)
            {
                var dbCivilStatus = dbCivilStates[i];
                var previousDbCivilStatus =
                    (i > 0) && (dbCivilStates[i - 1].MaritalEndDate == dbCivilStatus.MaritalStatusDate) ?
                    dbCivilStates[i - 1] : null;

                if (dbCivilStatus.MaritalStatus == marriedStatus)
                {
                    ret.Add(dbCivilStatus.ToPersonRelationType(cpr2uuidFunc));
                }
                else if (
                    dbCivilStatus.MaritalStatus == divorcedStatus || dbCivilStatus.MaritalStatus == widowStatus)
                {
                    // Statistics show that if previous row exists, it will be always 'married'
                    if (previousDbCivilStatus == null)
                    {
                        // Only add a relation if the previous row (married) does not exist
                        // Reverse times because we need the 'marriage' interval, not the 'divorce/widow'
                        ret.Add(dbCivilStatus.ToPersonRelationType(cpr2uuidFunc, true));
                    }
                }
            }
            return ret.ToArray();
        }

        class CaseInvariantCharComparer : IEqualityComparer<char>
        {
            public bool Equals(char x, char y)
            {
                return x.ToString().ToLower().Equals(y.ToString().ToLower());
            }

            public int GetHashCode(char obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}