﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPRBroker.Schemas.Part;

namespace CPRBroker.DAL.Part
{
    public partial class PersonRelationship
    {
        public enum RelationshipTypes
        {
            Parents,
            Children,
            Spouses,
            ReplacedBy,
            SubstituteFor
        }

        public Effect<Schemas.Part.PersonRelation> ToXmlType()
        {
            return new Effect<CPRBroker.Schemas.Part.PersonRelation>()
            {
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Value = new CPRBroker.Schemas.Part.PersonRelation()
                {
                    TargetUUID = this.RelatedPersonUUID
                }
            };
        }

        public static Schemas.Part.PersonRelations GetPersonRelations(IQueryable<PersonRelationship> relations)
        {
            return new CPRBroker.Schemas.Part.PersonRelations()
            {
                Children = FilterRelationsByType(relations, RelationshipTypes.Children),
                Parents = Array.ConvertAll<Effect<PersonRelation>, PersonRelation>(FilterRelationsByType(relations, RelationshipTypes.Children), (rel) => rel.Value),
                Spouses = FilterRelationsByType(relations, RelationshipTypes.Spouses),
                ReplacedBy = FilterRelationsByType(relations, RelationshipTypes.ReplacedBy).FirstOrDefault(),
                SubstituteFor = FilterRelationsByType(relations, RelationshipTypes.SubstituteFor),
            };
        }

        // TODO: ensure that the database is not queried in this method when filtering relations by type
        private static Effect<PersonRelation>[] FilterRelationsByType(IQueryable<PersonRelationship> relations, RelationshipTypes type)
        {
            return
            (
                from rel in relations
                where rel.RelationshipTypeId == (int)type
                select rel.ToXmlType()
            ).ToArray();
        }
    }
}
