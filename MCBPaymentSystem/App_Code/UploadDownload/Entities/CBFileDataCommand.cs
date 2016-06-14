using System;
using System.Collections.Generic;
using System.Text;

/*****************************************************************
  Class Name:  CBFileDataCommand
  Class Description: <A brief summary of what is the purpose of the class>
  Created By: Imran Zulfiqar
  Created Date: 13-07-2007
  Version No: 1.0
  Modification: <Mention the modification in the class >               
  Modification Date:
  Version No: <The version No after modification>

*****************************************************************/

namespace ENTITIES
{
    public class CBFileDataCommand //: IEntityCommand
    {
        private int _Id;
        private int _CorrespondingBankFileID;
        private string _CorrespondingBankUniqueId = "";
        private DateTime _ProcessingDate;
        private string _DraftNo;
        private DateTime _DraftPaidDate;
        private string _BeneficiaryName = "";
        private double _Amount;
        private string _ProcessingRemarks = "";
        private string _BranchCode;
        private double _Charges;
        private string _Remarks;
        private string _Type;
        private string _TEZStatus;
        private string _TCSNo;
        private DateTime _DispatchDate;
        private DateTime _DeliveryDate;
        private string _RecievedBy;
        private string _A_UserId = "";
        private DateTime _A_DateTime;
        private string _E_UserId;
        private DateTime _E_DateTime;


        public int Id
        {
            set
            {
                this._Id = value;
            }
            get
            {
                return this._Id;
            }
        }

        public int CorrespondingBankFileID
        {
            set
            {
                this._CorrespondingBankFileID = value;
            }
            get
            {
                return this._CorrespondingBankFileID;
            }
        }

        public string CorrespondingBankUniqueId
        {
            set
            {
                this._CorrespondingBankUniqueId = value;
            }
            get
            {
                return this._CorrespondingBankUniqueId;
            }
        }


        public DateTime ProcessingDate
        {
            set
            {
                this._ProcessingDate = value;
            }
            get
            {
                return this._ProcessingDate;
            }
        }

        public string DraftNo
        {
            set
            {
                this._DraftNo = value;
            }
            get
            {
                return this._DraftNo;
            }
        }

        public DateTime DraftPaidDate
        {
            set
            {
                this._DraftPaidDate = value;
            }
            get
            {
                return this._DraftPaidDate;
            }
        }

        public string BeneficiaryName
        {
            set
            {
                this._BeneficiaryName = value;
            }
            get
            {
                return this._BeneficiaryName;
            }
        }
        public double Amount
        {
            set
            {
                this._Amount = value;
            }
            get
            {
                return this._Amount;
            }
        }
        public string ProcessingRemarks
        {
            set
            {
                this._ProcessingRemarks = value;
            }
            get
            {
                return this._ProcessingRemarks;
            }
        }
        public string BranchCode
        {
            set
            {
                this._BranchCode = value;
            }
            get
            {
                return this._BranchCode;
            }
        }
        public double Charges
        {
            set
            {
                this._Charges = value;
            }
            get
            {
                return this._Charges;
            }
        }
        public string Type
        {
            set
            {
                this._Type = value;
            }
            get
            {
                return this._Type;
            }
        }
        public string TEZStatus
        {
            set
            {
                this._TEZStatus = value;
            }
            get
            {
                return this._TEZStatus;
            }
        }
        public string TCSNo
        {
            set
            {
                this._TCSNo = value;
            }
            get
            {
                return this._TCSNo;
            }
        }

        public DateTime DispatchDate
        {
            set
            {
                this._DispatchDate = value;
            }
            get
            {
                return this._DispatchDate;
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                this._DeliveryDate = value;
            }
            get
            {
                return this._DeliveryDate;
            }
        }

        public string Remarks
        {
            set
            {
                this._Remarks = value;
            }
            get
            {
                return this._Remarks;
            }
        }


        public string RecievedBy
        {
            set
            {
                this._RecievedBy = value;
            }
            get
            {
                return this._RecievedBy;
            }
        }


        public string A_UserId
        {
            set
            {
                this._A_UserId = value;
            }
            get
            {
                return this._A_UserId;
            }
        }

        public DateTime A_DateTime
        {
            set
            {
                this._A_DateTime = value;
            }
            get
            {
                return this._A_DateTime;
            }
        }

        public string E_UserId
        {
            set
            {
                this._E_UserId = value;
            }
            get
            {
                return this._E_UserId;
            }
        }

        public DateTime E_DateTime
        {
            set
            {
                this._E_DateTime = value;
            }
            get
            {
                return this._E_DateTime;
            }
        }
    }
}

