namespace CertifCooker.Models
{
    using System;

    internal class CertificateData
    {
        public CertificateData(string fullname, string birthday, string activity, DateTime creationDate, bool isFemale)
        {
            this.Fullname = fullname;
            this.Birthday = birthday;
            this.Activity = activity;
            this.CreationDate = creationDate;
            this.IsFemale = isFemale;
        }

        public string Fullname { get; }
        public string Birthday { get; }
        public string Activity { get; }
        public DateTime CreationDate { get; }
        public bool IsFemale { get; }
    }
}