﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace miVacationSurfer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class miVacationSurferEntities : DbContext
    {
        public miVacationSurferEntities()
            : base("name=miVacationSurferEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityReview> ActivityReviews { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<ActivityTypeSeason> ActivityTypeSeasons { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationActivityType> LocationActivityTypes { get; set; }
        public virtual DbSet<LocationReview> LocationReviews { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<SeasonActivity> SeasonActivities { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
