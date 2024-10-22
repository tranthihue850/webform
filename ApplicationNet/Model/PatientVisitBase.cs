using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationNet.Model
{
    public class PatientVisitBase
    {
        public string SetID { get; set; }
        public string PatientClass { get; set; }
        public string AssignedPatientLocation { get; set; }
        public string AdmissionType { get; set; }
        public string PreadmitNumber { get; set; }
        public string PriorPatientLocation { get; set; }
        public string AttendingDoctor { get; set; }
        public string ReferringDoctor { get; set; }
        public string ConsultingDoctor { get; set; }
        public string HospitalService { get; set; }
        public string TemporaryLocation { get; set; }
        public string PreadmitTestIndicator { get; set; }
        public string ReadmissionIndicator { get; set; }
        public string AdmitSource { get; set; }
        public string AmbulatoryStatus { get; set; }
        public string VIPIndicator { get; set; }
        public List<string> PatientAccountNumber { get; set; } = new List<string>();
        public string VisitNumber { get; set; }
    }
}
