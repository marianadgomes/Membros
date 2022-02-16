using System;
using System.CodeDom;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Collections.Generic;


namespace MemberRegistration
{
     class DataMember
    {
        SqlDataReader reader = null;
        SqlConnection conn = null;
        int rowsAffected = 0;
        
        
        /// <summary>
        /// Search for the member in the database by the typed name
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="connectionString"></param>
        /// <returns>List of Members</returns>
        public List<Members> GetMembers(string memberName, string connectionString)
        {
            try
            {
                string command = @"SELECT CodMember, MemberName, " +
                                 "  Email, Phone,  " +
                                 " BirthDate, IsBaptized, " +
                                 " Nationality, DateOfRegister " +
                                 " FROM dbo.Members" +
                                 " WHERE MemberName LIKE '%'+ @MemberName +'%' ";

                conn = new SqlConnection(connectionString);
                SqlCommand comm = new SqlCommand(command, conn);

                conn.Open();

                comm.Parameters.AddWithValue("@MemberName", memberName);

                // Executing the command and getting the result
                reader = comm.ExecuteReader();

                List<Members> membersList = new List<Members>();

                while (reader.Read())
                {
                    Members members = new Members(); 
                    
                    members.CodMember = (Convert.ToInt32(reader["CodMember"]));
                    members.Name = (Convert.ToString(reader["MemberName"]));
                    members.Email = (Convert.ToString(reader["Email"]));
                    members.BirthDate = (Convert.ToDateTime(reader["BirthDate"]));
                    members.Phone = (Convert.ToString(reader["Phone"]));
                    members.Nationality = (Convert.ToString(reader["Nationality"]));
                    members.IsBaptized = (Convert.ToBoolean(reader["IsBaptized"]));
                    members.DateOfRegister = (Convert.ToDateTime(reader["DateOfRegister"]));
                    membersList.Add(members);
                }

                return membersList;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // close datareader
                if (reader != null)
                {
                    reader.Close();
                }
                // close connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Add a new member in the database
        /// </summary>
        /// <param name="member"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public string AddMembers(Members member, string connectionString)
        {
            try
            {
                string command = "INSERT INTO dbo.Members (MemberName,   Email,   Phone,  BirthDate, IsBaptized, Nationality , DateOfRegister)" +
                "VALUES(@MemberName,   @Email,   @Phone,  @BirthDate, @IsBaptized, @Nationality , @DateOfRegister)";

                conn = new SqlConnection(connectionString);
                SqlCommand comm = new SqlCommand(command, conn);
                
                comm.Parameters.AddWithValue("@MemberName", member.Name);
                comm.Parameters.AddWithValue("@Email", member.Email);
                comm.Parameters.AddWithValue("@Phone", member.Phone);
                comm.Parameters.AddWithValue("@BirthDate", member.BirthDate);
                comm.Parameters.AddWithValue("@IsBaptized", member.IsBaptized);
                comm.Parameters.AddWithValue("@Nationality", member.Nationality);
                comm.Parameters.AddWithValue("@DateOfRegister", member.DateOfRegister);

                conn.Open();

                // Running the command on the database
                rowsAffected = comm.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return "Member NOT registered!";
                }
                else 
                {
                    return "Member successfully registered!";
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // Close connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        
        /// <summary>
        /// Delete a member by his code 
        /// </summary>
        /// <param name="memberCode"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
       public string DeleteMembers(int memberCode, string connectionString)
        {
            try
            {
                string command = @"DELETE "+
                                 " FROM dbo.Members" +
                                 " WHERE CodMember = @CodMember  ";

                conn = new SqlConnection(connectionString);
                SqlCommand comm = new SqlCommand(command, conn);

                conn.Open();

                comm.Parameters.AddWithValue("@CodMember", memberCode);

                // / Running the command on the database
                rowsAffected = comm.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return "Member not exist!";
                }
                else 
                {
                    return "Member successfully deleted!";
                }
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // Close connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Alter a member in the database
        /// </summary>
        /// <param name="memberCode"></param>
        /// <param name="member"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
       public string AlterMembers(int memberCode, Members member, string connectionString)
       {
           try
           {
               string command = "UPDATE dbo.Members SET" +
                                " MemberName = @MemberName,   Email = @Email, Phone =  @Phone, BirthDate =  @BirthDate, IsBaptized = @IsBaptized, Nationality = @Nationality " +
                                "WHERE CodMember = @CodMember ";

               conn = new SqlConnection(connectionString);
               SqlCommand comm = new SqlCommand(command, conn);
                
               comm.Parameters.AddWithValue("@CodMember", memberCode);
               comm.Parameters.AddWithValue("@MemberName", member.Name);
               comm.Parameters.AddWithValue("@Email", member.Email);
               comm.Parameters.AddWithValue("@Phone", member.Phone);
               comm.Parameters.AddWithValue("@BirthDate", member.BirthDate);
               comm.Parameters.AddWithValue("@IsBaptized", member.IsBaptized);
               comm.Parameters.AddWithValue("@Nationality", member.Nationality);

               conn.Open();

               //  Running the command on the database
               rowsAffected = comm.ExecuteNonQuery();

               if (rowsAffected == 0)
               {
                   return "Member not exist!";
               }
               else 
               {
                   return "Member successfully registered!";
               }
           }
           catch (SqlException ex)
           {
               throw ex;
           }
           finally
           {
               // Close connection
               if (conn != null)
               {
                   conn.Close();
               }
           }
       }
    }
}