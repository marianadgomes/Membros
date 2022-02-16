using System;
using System.Collections.Generic;


namespace MemberRegistration
{
    public class Members
    {
        string result = "";
        DataMember dataMember = new DataMember();
        
        private int codMember;
        public int CodMember
        {
            get
            {
                return codMember;
            }
            set
            {
                codMember = value;
            }
        }
        
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }
            
        private bool isBaptized;
        public bool IsBaptized
        {
            get
            {
                return isBaptized;
            }
            set
            {
                isBaptized = value;
            }
        }
        
        private string nationality;
        public string Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
            }
        }
        
        private DateTime dateOfRegister;
        public DateTime DateOfRegister
        {
            get
            {
                return dateOfRegister;
            }
            set
            {
                dateOfRegister = value;
            }
        }
        
        
        public Members(int memberId, string memberName, string memberEmail, string phoneNumber, DateTime dateOfBirth, bool isMemberBaptized, string memberNationality)
        {
        }

        public Members()
        {
            
        }

        public string InsertMember(Members member, string connectionString)
        {
            result = dataMember.AddMembers(member, connectionString);
            return result;
        }
        
      
        public string DeleteMembers(int codeMember, string connectionString)
        {
            result = dataMember.DeleteMembers(codeMember, connectionString);
            return result;
        }
        
        
        public string EditMember(int memberId, Members member, string connectionString)
        {
            result = dataMember.AlterMembers(memberId, member, connectionString);
            return result;
        }
        
        
        public List<Members> ViewMember(string memberName, string connectionString)
        {
            List<Members> memberList = new List<Members>();
            memberList = dataMember.GetMembers(memberName, connectionString);
            return memberList;
        }
        
        
    }
}