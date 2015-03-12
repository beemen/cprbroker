﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Providers.ServicePlatform.CprService2;
using CprBroker.Providers.CprServices;
using System.Net;
using CprBroker.Engine.Part;
using CprBroker.Engine;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;

namespace CprBroker.Providers.ServicePlatform
{
    public partial class ServicePlatformDataProvider
    {
        public Kvit CallService(string serviceUuid, string gctpMessage, out string retXml)
        {
            // Binding
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            // End point
            var endPointAddress = new EndpointAddress(this.Url);

            var service = new CprService2.CprServicePortTypeClient(binding, endPointAddress);

            // Set credentials
            service.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySerialNumber, this.CertificateSerialNumber);

            using (var callContext = this.BeginCall(serviceUuid, serviceUuid))
            {
                var invocationContext = GetInvocationContext(serviceUuid);

                retXml = service.forwardToCPRService(invocationContext, gctpMessage);
                var kvit = Kvit.FromResponseXml(retXml);
                if (kvit.OK)
                {
                    callContext.Succeed();
                }
                else
                {
                    callContext.Fail();
                }
                return kvit;
            }
        }

        public InvocationContextType GetInvocationContext(string serviceUuid)
        {
            return new InvocationContextType()
            {
                ServiceAgreementUUID = this.ServiceAgreementUuid,
                ServiceUUID = serviceUuid,
                UserSystemUUID = this.UserSystemUUID,
                UserUUID = this.UserUUID,
                OnBehalfOfUser = null,
                CallersServiceCallIdentifier = null,
                AccountingInfo = null
            };
        }
    }
}