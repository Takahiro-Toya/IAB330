using System;
using SQLite;
using Xamarin.Forms;

namespace SnackRoulette.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }
        //[PrimaryKey, AutoIncrement]
        //public int Id { get; set; }
        [PrimaryKey]
        public string email { get; set; }
        public string userName { get; set; }
        [MaxLength(12)]
        public string password { get; set; }

    }
}
