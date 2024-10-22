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
using ApplicationNet.Common;
using ApplicationNet.Model;

namespace ApplicationNet
{
    public class ClassParse
    {
        public ClassParse() 
        {
            
        }

        public void ParseData()
        {                      
            string hl8Message = @"MSH|^~\&|MegaReg|XYZHospC|SuperOE|XYZImgCtr|20060529090131-0500|S001|ADT^A01^ADT_A01|01052901|P|2.5
                    EVN|N001|200605290901|200606290901|R001|O001|200605290900
                    PID|123|234|56782445^^^UAReg^PI|AlterID001|KLEINSAMPLE^BARRY^Q^JR|MotherId001|19620910|M|Alias001|2028-9^^HL70005^RA99113^^XYZ|260 GOODWIN CREST DRIVE^^BIRMINGHAM^AL^35209^^M~NICKELL’S PICKLES^10000 W 100TH AVE^BIRMINGHAM^AL^35200^^O|A01|A02|A03|A04|A05|A06|0105I30001^^^99DEF^AN
                    PV1||I|W^389^1^UABH^^^^3||||12345^MORGAN^REX^J^^^MD^0010^UAMC^L||67890^GRAINGER^LUCY^X^^^MD^0010^UAMC^L|MED|||||A0||13579^POTTER^SHERMAN^T^^^MD^0010^UAMC^L||8675309|||||||||||||||||||||||||200605290900
                    OBX|1|NM|^Body Height||1.80|m^Meter^ISO+||N|||F
                    OBX|2|NM|^Body Weight||79|kg^Kilogram^ISO+||N|||F
                    AL1|1||^ASPIRIN
                    DG1|1||786.50^CHEST PAIN, UNSPECIFIED^I9|||A";

            var parser = new PipeParser();

            var message = parser.Parse(hl8Message) as IMessage;

            if (message is ADT_A01 adtMessage)
            {
                ConvertData cv = new ConvertData();
                PIdBase pId = new PIdBase();
                cv.ConvertToMsh(adtMessage, pId);
                EvnBase evn = new EvnBase();
                cv.ConvertToEvn(adtMessage, evn);
                var patient = adtMessage.PID;
                Console.WriteLine($"Patient Name: {patient.GetPatientName(0).FamilyName}");
                var abc = patient.GetPatientName(0).FamilyName;
            }
            else
            {
                Console.WriteLine("Not an ADT_A01 message.");
            }
        }
    }
}
