using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.Mappers;

namespace miVacationSurfer.ViewModel
{
    public class ReviewViewModel
    {
        miVacationSurfer.Region region = new miVacationSurfer.Region();

        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<ActivityType> ActivityTypes { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Activity> Activitys { get; set; }

        
      
    }
}