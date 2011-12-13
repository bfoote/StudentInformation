using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentInformation.DL;
using System.Xml.Serialization;
using System.IO;


namespace StudentInformation.OB
{
    public class CStudents : CollectionBase
    {
        private List<CStudent> _oStudents;

        public List<CStudent> Students
        {
            get { return _oStudents; }
       
        }

        public int Count()
        {
            return _oStudents.Count;
        }




        public void LoadXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CStudent>));
            TextReader textReader = new StreamReader("Students.xml");
            _oStudents = (List<CStudent>)serializer.Deserialize(textReader);
            textReader.Close();
            textReader.Dispose();
            textReader = null;
        }

        public void Load()
        {
            List<CStudent> _oStudents = new List<CStudent>();
            CFile oFile = new CFile();
            string sRecords = oFile.Read();
            string[] arStudents = sRecords.Split('|');
            foreach (string sRecord in arStudents)
            {
                CStudent oStudent = new CStudent(sRecord);
                this.Add(oStudent);
            }




        }
        public CStudent Item(int value)
        {
            return _oStudents[value];
        }
        //public CStudent ItemByKey(string Key)
        //{
        //    //return _oStudents.S
        //}

        public void SaveXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CStudent>));
            TextWriter textWriter = new StreamWriter("Students.xml");
            serializer.Serialize(textWriter, _oStudents);
            textWriter.Close();
            textWriter.Dispose();
            textWriter = null;
        }

        public bool Save()
        {
            foreach (CStudent oStudent in this.Students)
            {
                oStudent.Write();
            }
            return true;
        }
        public void Add(CStudent oStudent)
        {
            _oStudents.Add(oStudent);
        }

        public CStudents()
        {
            _oStudents = new List<CStudent>();
        }


    }
}
