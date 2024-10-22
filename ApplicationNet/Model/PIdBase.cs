using NHapi.Model.V25.Datatype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationNet.Model
{
    public class PIdBase
    {
        public string PatientId { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string AddressDisplay { get; set; }
        public AddressInfo Address { get; set; }
                
        public List<string> PatientIdentifierList { get; set; } = new List<string>();
        public string AlternatePatientId { get; set; }
        public List<PatientName> PatientNames { get; set; } = new List<PatientName>();
        public List<AddressInfo> PatientAddresses { get; set; } = new List<AddressInfo>();
        public string AdministrativeSex { get; set; }
        public List<string> PatientAliases { get; set; } = new List<string>();
        public string Race { get; set; }
        public string PatientAccountNumber { get; set; }
        public string SSNNumber { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string MothersIdentifier { get; set; }
        public string EthnicGroup { get; set; }
        public string BirthPlace { get; set; }
        public string MultipleBirthIndicator { get; set; }
        public string BirthOrder { get; set; }
        public string PatientDeathDateTime { get; set; }

        public List<string> GetIdentifierList(IEnumerable<CX> identifiers)
        {
            var list = new List<string>();
            foreach (var id in identifiers)
            {
                list.Add(id?.IDNumber.Value ?? "N/A");
            }
            return list;
        }

        public List<string> GetAliasList(IEnumerable<XCN> aliases)
        {
            var list = new List<string>();
            foreach (var alias in aliases)
            {
                list.Add(alias?.IDNumber.Value ?? "N/A");
            }
            return list;
        }

        public List<PatientName> GetPatientNames(IEnumerable<XPN> names)
        {
            var list = new List<PatientName>();
            foreach (var name in names)
            {
                list.Add(new PatientName
                {
                    FamilyName = name.FamilyName?.Surname.Value ?? "N/A",
                    GivenName = name.GivenName?.Value ?? "N/A",
                    // MiddleName = name.MiddleName?.Value ?? "N/A"
                });
            }
            return list;
        }

        static List<AddressInfo> GetPatientAddresses(IEnumerable<XAD> addresses)
        {
            var list = new List<AddressInfo>();
            foreach (var address in addresses)
            {
                list.Add(new AddressInfo
                {
                    StreetName = address.StreetAddress?.StreetName.Value ?? "N/A",
                    StreetAddress = address.StreetAddress.StreetOrMailingAddress?.Value ?? "N/A",
                    OtherDesignation = address.OtherDesignation?.Value ?? "N/A",
                    City = address.City?.Value ?? "N/A",
                    State = address.StateOrProvince?.Value ?? "N/A",
                    ZipCode = address.ZipOrPostalCode?.Value ?? "N/A",
                    Country = address.Country?.Value ?? "N/A",
                    AddressType = address.AddressType?.Value ?? "N/A"
                });
            }
            return list;
        }
    }

    public class PatientName
    {
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
    }

    public class AddressInfo
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string StreetAddress1 { get; set; }
        public string OtherDesignation { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
        public string StreetAddress { get; set; }
        public string StreetName { get; set; }
        public AddressInfo GetAddressInfo(XAD address)
        {            
            return new AddressInfo
            {
                Street = address.StreetAddress.StreetOrMailingAddress.ToString() ?? "N/A",
                City = address.City?.Value ?? "N/A",
                State = address.StateOrProvince?.Value ?? "N/A",
                Zip = address.ZipOrPostalCode?.Value ?? "N/A",
                Country = address.Country?.Value ?? "N/A",
                StreetAddress1 = address.StreetAddress?.StreetName?.Value ?? "N/A",
                AddressType = address.AddressType.Value
            };
        }

        public string FormatAddress(AddressInfo address)
        {
            if (address == null)
                return "N/A";

            return $"{address.Street}, {address.City}, {address.State}, {address.Zip}";
        }
    }
}
