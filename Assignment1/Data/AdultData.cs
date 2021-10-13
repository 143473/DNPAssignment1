using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using Assignment1.Models;
using FileData;


namespace Assignment1.Data
{
    public class AdultData : IAdultData
    {
        private FileContext FileContext;

        public AdultData()
        {
            FileContext = new FileContext();
        }

        public IList<Adult> GetAdults()
        {
            return FileContext.Adults;
        }

        public void AddAdult(Adult newAdult)
        {
            var nextId = FileContext.Adults.Max(adult => adult.Id);
            newAdult.Id = ++nextId;
            FileContext.Adults.Add(newAdult);
            FileContext.SaveChanges();
        }

        public void RemoveAdult(int adultId)
        {
            FileContext.Adults.RemoveAt(adultId);
            FileContext.SaveChanges();
        }

        public void UpdateAdult(Adult adult)
        {
            Adult toUpdate = FileContext.Adults.First(t => t.Id == adult.Id);
            FileContext.Adults.Remove(toUpdate);
            FileContext.Adults.Add(adult);
            FileContext.SaveChanges();
        }

        public Adult GetAdult(int id)
        {
            return FileContext.Adults.FirstOrDefault(t => t.Id == id);
        }

        public List<Adult> SearchFilter(string searchByName, string filter, string filter2)
        {
            var adultsToShow = FileContext.Adults.Where(t =>
                (!searchByName.Equals("") && (t.FirstName.Contains(searchByName, StringComparison.OrdinalIgnoreCase) ||
                                              t.LastName.Contains(searchByName, StringComparison.OrdinalIgnoreCase)) ||
                 searchByName.Equals("")) &&
                (!filter2.Equals("") &&
                 (t.Sex.Equals(filter2) || (t.EyeColor.Equals(filter2) && filter.Equals("EyeColor")) ||
                  (t.HairColor.Equals(filter2) && filter.Equals("HairColor")) || t.JobTitle.JobTitle.Equals(filter2)) ||
                 filter2.Equals("")
                )
            ).ToList();
            var ordered = adultsToShow.OrderBy(t => t.Id).ToList();
            return ordered;
        }
    }
}