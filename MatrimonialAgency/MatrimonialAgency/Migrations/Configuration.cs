namespace MatrimonialAgency.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Context;
    using System.Collections.Generic;
    using Models.Nomenclatures;

    internal sealed class Configuration : DbMigrationsConfiguration<MatrimonialAgency.Context.AgencyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MatrimonialAgency.Context.AgencyContext context)
        {
            PopulateGenderEnum(context);
            
            
        }

        private void PopulateGenderEnum(AgencyContext context)
        {
            var genderList = new List<Gender>
            {
                new Gender() { GenderId =1, Name ="Male" },
                new Gender(){ GenderId =2, Name ="Female" }
            }; 

            foreach (var gender in genderList)
            {
                context.Genders.AddOrUpdate(p => p.Name, gender);
            }
        }
    }
}
