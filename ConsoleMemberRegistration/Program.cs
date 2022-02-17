using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection.Metadata.Ecma335;
using MemberRegistration;


namespace ConsoleMemberRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get string connection from App.config
            string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["LChurchConnection"]);

            int option = 0;
            Members members = new Members();
            string result = "";

            Console.WriteLine("Type 1 to register a new member, 2 to search for existing member, 3 to delete a member or 4 to update:");
            option = Convert.ToInt16(Console.ReadLine());

            //Register a new member
            if (option == 1)
            {
                string isbaptized = "";
                Console.WriteLine("Member Registration");
                try
                {
                    Console.WriteLine("Type member name:");
                    members.Name = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Email:");
                    members.Email = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Phone:");
                    members.Phone = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Birth of Date: (2000/01/24)");
                    members.BirthDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("IsBaptized?: (yes/no)");
                    isbaptized = Convert.ToString(Console.ReadLine());
                    if (isbaptized.ToLower() == "yes")
                    {
                        members.IsBaptized = true;
                    }
                    else
                    {
                        members.IsBaptized = false;
                    }
                    Console.WriteLine("Nationality:");
                    members.Nationality = Convert.ToString(Console.ReadLine());
                    members.DateOfRegister = DateTime.Now;

                    result = members.InsertMember(members, connectionString);
                    
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            //search for existing member
            else if (option == 2)
            {
                try
                {
                    string nMember = "";
                    Console.WriteLine("Type member name:");
                    nMember = Console.ReadLine();
                    List<Members> memberList = new List<Members>();

                    memberList = members.ViewMember(nMember, connectionString);

                    if (memberList != null &&  memberList.Count != 0  )
                    {
                        foreach (var mbr in memberList)
                        {
                            Console.Write("Member code: ");
                            Console.WriteLine(mbr.CodMember);
                            Console.Write("Name: ");
                            Console.WriteLine(mbr.Name);
                            Console.Write("Email: ");
                            Console.WriteLine(mbr.Email);
                            Console.Write("Phone number: ");
                            Console.WriteLine(mbr.Phone);
                            Console.Write("Date of Birth: ");
                            Console.WriteLine(mbr.BirthDate);
                            Console.Write("Nationality: ");
                            Console.WriteLine(mbr.Nationality);
                            Console.Write("Member is baptized: ");
                            Console.WriteLine(mbr.IsBaptized);
                            Console.Write("Date of Register: ");
                            Console.WriteLine(mbr.DateOfRegister);
                            Console.WriteLine("----------------------------------- ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Member not found.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
    
            //delete a existing member
            else if (option == 3)
            {
                try
                {
                    int code = 0;
                    Console.WriteLine("Enter member's code:");
                    code = Convert.ToInt32(Console.ReadLine());

                    result = members.DeleteMembers(code, connectionString);
                    
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            //update a existing member
            else if (option == 4)
            {
                int code = 0;
                string isbaptized = "";
                try
                {
                    Console.WriteLine("Type the code of the member you want to update:");
                    code = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Name");
                    members.Name = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Email:");
                    members.Email = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Phone:");
                    members.Phone = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Birth of Date: (2000/01/24)");
                    members.BirthDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("IsBaptized?: (yes/no)");
                    isbaptized = Convert.ToString(Console.ReadLine());
                    if (isbaptized.ToLower() == "yes")
                    {
                        members.IsBaptized = true;
                    }
                    else
                    {
                        members.IsBaptized = false;
                    }
                    Console.WriteLine("Nationality:");
                    members.Nationality = Convert.ToString(Console.ReadLine());
                    members.DateOfRegister = DateTime.Now;

                    result = members.EditMember(code, members, connectionString);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            else 
            {
                Console.WriteLine("Invalid option!");
            }
        }
    }
}