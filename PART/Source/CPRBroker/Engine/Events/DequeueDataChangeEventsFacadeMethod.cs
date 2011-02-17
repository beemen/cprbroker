﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas.Part;
using CprBroker.Schemas.Part.Events;

namespace CprBroker.Engine.Events
{
    public class DequeueDataChangeEventsFacadeMethod : FacadeMethodInfo<BasicOutputType<DataChangeEventInfo[]>>
    {
        public int MaxCount = 0;

        public DequeueDataChangeEventsFacadeMethod(int maxCount, string appToken, string userToken)
            : base(appToken, userToken)
        {
            this.MaxCount = maxCount;
        }

        public override StandardReturType ValidateInput()
        {
            if (MaxCount <= 0 || MaxCount > 10000)
            {
                return StandardReturType.ValueOutOfRange(MaxCount);
            }
            return StandardReturType.OK();
        }

        public override void Initialize()
        {
            base.Initialize();
            SubMethodInfos = new SubMethodInfo[] { new Events.DequeueDataChangeEventSubMethodInfo(MaxCount) };
        }

        public override BasicOutputType<DataChangeEventInfo[]> Aggregate(object[] results)
        {
            return new BasicOutputType<DataChangeEventInfo[]>()
            {
                StandardRetur = StandardReturType.OK(),
                Item = results[0] as DataChangeEventInfo[],
            };
        }
       
    }
}
