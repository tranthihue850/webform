using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model;
using NHapi.Model.V25.Message;
using NHapi.Model.V25.Datatype;
using ApplicationNet.Model;
using System.Net;

namespace ApplicationNet.Common
{
    public class ConvertData
    {
        public void ConvertToMsh(ADT_A01 dt, PIdBase pid)
        {
            if (dt.PID != null)
            {
                var patient = dt.PID;
                AddressInfo address = new AddressInfo();                
                pid.PatientId = patient.PatientID?.IDNumber.Value ?? "N/A";
                pid.FamilyName = patient.GetPatientName(0)?.FamilyName?.Surname.Value ?? "N/A";
                pid.GivenName = patient.GetPatientName(0)?.GivenName?.Value ?? "N/A";
                pid.DateOfBirth = patient.DateTimeOfBirth.Time.Value ?? "N/A";
                pid.Gender = patient.AdministrativeSex?.Value ?? "N/A";
                pid.AddressDisplay = address.FormatAddress(address.GetAddressInfo(patient.GetPatientAddress(0))); //.StreetAddress.ToString() ?? "N/A";
                pid.Address = address.GetAddressInfo(patient.GetPatientAddress(0));
                pid.PatientIdentifierList = pid.GetIdentifierList(patient.GetPatientIdentifierList());
            }
        }

        public void ConvertToEvn(ADT_A01 dt, EvnBase evn)
        {
            if (dt.PID != null)
            {
                var noti = dt.EVN;                
                evn.EventTypeCode = noti.EventTypeCode?.Value ?? "N/A";
                evn.RecordedDateTime = noti.RecordedDateTime.Time?.Value ?? "N/A";
                evn.DateTimePlannedEvent = noti.DateTimePlannedEvent?.Time.Value ?? "N/A";
                evn.EventReasonCode = noti.EventReasonCode?.Value ?? "N/A";                
                evn.OperatorID = noti.GetOperatorID()[0].IDNumber.Value ?? "N/A";
                evn.EventOccurred = noti.EventOccurred.Time.Value ?? "N/A";
            }
        }
    }
}
