using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using model = MoeSto.Web.Models ;
using MoeSto.DAC;
namespace XMLParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataAccessManagerDataContext dbContext = new DataAccessManagerDataContext();
            const string fileName = @"C:\Users\spadmin\documents\visual studio 2012\Projects\MoeSto\XMLParser\XML\XMLFile.xml";
            XDocument xDoc = XDocument.Load(fileName);
            var companies = xDoc.Root;
            List<Company> listOfCompanies = new List<Company>();
            foreach (var company in companies.Elements("Company"))
            {
                var dbCompany = new Company();
                dbCompany.Name = GetElementValue(company.Element("Name"));

                dbCompany.Unp = GetInt(company.Element("Unp"));
                dbCompany.Address = GetElementValue(company.Element("Address"));
                dbCompany.Email = GetElementValue(company.Element("Email"));
                dbCompany.Phones = GetElementValue(company.Element("Phones"));
                //dbCompany.Type = company.Element("Type").Value;
                //dbCompany.CatalogUrl = company.Element("CatalogUrl").Value;
                //dbCompany.FoundOnCardone = company.Element("FoundOnCardone").Value;
                //dbCompany.CardoneStatus = company.Element("CardoneStatus").Value;
                //dbCompany.CardoneContractNo = company.Element("CardoneContractNo").Value;
                //dbCompany.CardoneContractStatus = company.Element("CardoneContractStatus").Value;
                GetCoordinates(company.Element("Coordinates"), dbCompany );
                listOfCompanies.Add(dbCompany);
            }
            dbContext.Companies.InsertAllOnSubmit(listOfCompanies);
            dbContext.SubmitChanges();
        }

        private static string GetElementValue(XElement element)
        {
            if (element != null)
            {
                if (!string.IsNullOrEmpty(element.Value))
                {
                    return element.Value;
                }
            }
            return string.Empty;
        }

        private static void GetCoordinates(XElement element, Company dbCompany)
        {
            if (element != null)
            {
                if (!string.IsNullOrEmpty(element.Value))
                {
                    var coords = element.Value.Split(',');
                    if (coords.Length > 1)
                    {
                        dbCompany.Latitude = GetDouble(coords[1]);
                        dbCompany.Longitude = GetDouble(coords[0]);
                    }
                }
            }
            
        }

        private static double GetDouble(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                double result;
                if (double.TryParse(s, out result))
                {
                    return result;
                }
            }
            return 0;
        }


        private static int GetInt(XElement element)
        {
            if(element!=null)
            {
                if (!string.IsNullOrEmpty(element.Value))
                {
                    int result;
                    if (int.TryParse(element.Value, out result))
                    {
                        return result;
                    }
                }
            }
            return 0;
        }
    }
}
