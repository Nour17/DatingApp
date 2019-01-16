using System.Collections.Generic;
using Newtonsoft.Json;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUserTypes(){

            var userTypesData = System.IO.File.ReadAllText("Data/UserTypeSeedData.json");
            var userTypesDeserialized = JsonConvert.DeserializeObject<List<UserType>>(userTypesData);

            foreach(var userType in userTypesDeserialized){
                _context.UserTypes.Add(userType);
            }

            _context.SaveChanges();
        }
    }
}