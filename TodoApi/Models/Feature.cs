using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApi.Models
{
    public partial class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public string Status { get; set; }
        public bool Biometrics { get; set; }
        public bool Verificationcode { get; set; }
        public int? Single { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
    }
}
