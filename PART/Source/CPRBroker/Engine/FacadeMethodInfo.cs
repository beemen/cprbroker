﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas.Part;

namespace CprBroker.Engine
{
    public class FacadeMethodInfo<TOutput> where TOutput : class, IBasicOutput, new()
    {
        public FacadeMethodInfo()
        { }

        public FacadeMethodInfo(string appToken, string userToken)
        {
            ApplicationToken = appToken;
            UserToken = userToken;
        }

        public virtual StandardReturType ValidateInput()
        {
            return StandardReturType.OK();
        }

        public virtual void Initialize()
        {
            if (InitializationMethod != null)
            {
                InitializationMethod();
            }
        }
        public Action InitializationMethod = () => { };


        public virtual TOutput Aggregate(object[] results)
        {
            if (AggregationMethod != null)
            {
                return AggregationMethod(results);
            }
            else
            {
                return default(TOutput);
            }
        }

        public Func<object[], TOutput> AggregationMethod =
            (results) =>
            {
                if (results != null && results.Length == 1)
                {
                    return (TOutput)(object)results[0];
                }
                else
                {
                    return default(TOutput);
                }
            };

        public virtual bool IsValidResult(TOutput output)
        {
            return !object.Equals(output, default(TOutput));
        }

        public string ApplicationToken;
        public string UserToken;

        public SubMethodInfo[] SubMethodInfos = new SubMethodInfo[0];
    }
}
