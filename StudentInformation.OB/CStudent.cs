using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentInformation.DL;
using System.Runtime.Serialization;

namespace StudentInformation.OB
{
    

    public class CStudent : CPerson
    {
        // Create our fields or modular level variables

        private Guid _Id;
        private float _fltGPA;
        private string _StudentId;
        private string _sProgram;
        const string DELIM = "|";

        #region Properties

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public float GPA
        {
            get { return _fltGPA; }
            set { _fltGPA = value; }
        }

        public string StudentId
        {
            get { return _StudentId; }
            set { _StudentId = value; }
        }

        public string Program
        {
            get { return _sProgram; }
            set { _sProgram = value; }
        }

        #endregion
        #region Constructors
        
        // Constructor #1
        public CStudent()
        {
            _Id = Guid.NewGuid();
            _fltGPA = 0;
            _StudentId = string.Empty;
            _sProgram = string.Empty;
        }

        // Constructor #2
        public CStudent(Guid vId)
        {
            _Id = vId;
            _fltGPA = 0;
            _StudentId = string.Empty;
            _sProgram = string.Empty;
        }

        // Constructor #3
        public CStudent(Guid vId, 
                        float vfGPA, 
                        string vsStudentId, 
                        string vsProgram)
        {
            _Id = vId;
            _fltGPA = vfGPA;
            _StudentId = vsStudentId;
            _sProgram = vsProgram;
        }

        // Constructor #4
        public CStudent(string vsRecord)
        {
            string[] sRecord = vsRecord.Split('|');
            Guid.TryParse(sRecord[0], out _Id);
            _fltGPA = float.Parse(sRecord[0]);
            _StudentId = sRecord[0];
            _sProgram = sRecord[0];
        }


        #endregion

        public bool Write()
        {
            try
            {
                CFile oFile = new CFile();
                string sOutput = string.Empty;

                // TODO: Create the output stream
                FormatOutput(ref sOutput);

                // Save the output stream
                oFile.Write(sOutput);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void FormatOutput(ref string rsOutput)
        {
            try
            {
                rsOutput = _Id 
                            + DELIM + FirstName
                            + DELIM + LastName
                            + DELIM + Address1.StAddress
                            + DELIM + Address1.City
                            + DELIM + Address1.State
                            + DELIM + Address1.ZIP
                            + DELIM + Address1.AddressType
                            + DELIM + _fltGPA
                            + DELIM + _sProgram;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
