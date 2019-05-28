using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSocialNetwork.DomainModel.Entities;
using TheSocialNetwork.DomainModel.Interfaces.Repositories;

namespace TheSocialNetwork.DataAccess.Repositories
{
    class ProfileStoredProcedureRepository : IProfileRepository
    {
        private SqlConnection _sqlConnection = new SqlConnection(DataAccess.Properties.Settings.Default.DbConnectionString);

        public void Create(Profile profile)
        {
            var sqlCommand = new SqlCommand("CreateProfile", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("Id", profile.Id);
            sqlCommand.Parameters.AddWithValue("Name", profile.Name);
            sqlCommand.Parameters.AddWithValue("Birthday", profile.Birthday);
            sqlCommand.Parameters.AddWithValue("Address", profile.Address);
            sqlCommand.Parameters.AddWithValue("PhotoUrl", profile.PhotoUrl);
            sqlCommand.Parameters.AddWithValue("Country", profile.Country);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void Delete(Guid post)
        {
            var sqlCommand = new SqlCommand("DeleteProfile", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("id", post);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public IEnumerable<Profile> Read(Guid post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> ReadAll()
        {
            var profiles = new List<Profile>();

            var sqlCommand = new SqlCommand("GetAllProfile", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var currentProfile = new Profile();
                currentProfile.Id = Guid.Parse(reader["Id"].ToString());
                currentProfile.Name = reader["Name"].ToString();
                currentProfile.Birthday = DateTime.Parse(reader["Birthday"].ToString());
                currentProfile.PhotoUrl = reader["PhototUrl"].ToString();
                // currentProfile.Friends = criar storageprocedure GetProfileFriends
                profiles.Add(currentProfile);
            }
            _sqlConnection.Close();
            return profiles;
        }

        public void Update(Profile profile)
        {
            var sqlCommand = new SqlCommand("UpdateProfile", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("id", profile);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        Profile IProfileRepository.Read(Guid post)
        {
            throw new NotImplementedException();
        }
    }
}
