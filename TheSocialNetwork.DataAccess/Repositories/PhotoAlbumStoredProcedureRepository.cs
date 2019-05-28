using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSocialNetwork.DomainModel.Entities;
using TheSocialNetwork.DomainModel.Interfaces.Repositories;

namespace TheSocialNetwork.DataAccess.Repositories
{
    public class PhotoAlbumStoredProcedureRepository : IPhotoAlbumRepository
    {
        private SqlConnection _sqlConnection = new SqlConnection(DataAccess.Properties.Settings.Default.DbConnectionString);

        public void Create(PhotoAlbum photoAlbum)
        {
            var sqlCommand = new SqlCommand("CreatePhotoAlbum", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("Id", photoAlbum.Id);
            sqlCommand.Parameters.AddWithValue("Profile", photoAlbum.Profile);
            sqlCommand.Parameters.AddWithValue("Description", photoAlbum.Description);
            sqlCommand.Parameters.AddWithValue("CreationDate", photoAlbum.CreationDate);
            sqlCommand.Parameters.AddWithValue("Photos", photoAlbum.Photos);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void Delete(Guid photoAlbumId)
        {
            var sqlCommand = new SqlCommand("DeletePhotoAlbum", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("id", photoAlbumId);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public PhotoAlbum Read(Guid photoAlbumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhotoAlbum> ReadAll()
        {
            var photoalbum = new List<PhotoAlbum>();

            var sqlCommand = new SqlCommand("GetAllPhotoAlbums", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var currentPhotoAlbum = new PhotoAlbum();
                currentPhotoAlbum.Id = Guid.Parse(reader["Id"].ToString());
                currentPhotoAlbum.Title = reader["Name"].ToString();
                currentPhotoAlbum.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());
                currentPhotoAlbum.Description = reader["Description"].ToString();
                photoalbum.Add(currentPhotoAlbum);
            }
            _sqlConnection.Close();
            return photoalbum;
        }

        public void Update(PhotoAlbum photoAlbum)
        {
            var sqlCommand = new SqlCommand("UpdatePhotoAlbum", _sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("id", photoAlbum);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
