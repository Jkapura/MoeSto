using System.Collections.Generic;
using System.Xml.Linq;
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
            List<Companies> listOfCompanies = new List<Companies>();
            List<CompanyDetails> listOfCompanyDetails = new List<CompanyDetails>();
            foreach (var company in companies.Elements("Company"))
            {
                var dbCompany = new Companies();
                var dbCompanyDetails = new CompanyDetails();

                dbCompanyDetails.Name = GetElementValue(company.Element("Name"));
                dbCompanyDetails.Unp = GetInt(company.Element("Unp"));
                dbCompanyDetails.Address = GetElementValue(company.Element("Address"));
                dbCompanyDetails.Email = GetElementValue(company.Element("Email"));
                dbCompanyDetails.Phones = GetElementValue(company.Element("Phones"));
                dbCompanyDetails.CatalogUrl = company.Element("CatalogUrl").Value;
                dbCompanyDetails.FoundOnCardone = GetBool(company.Element("FoundOnCardone"));
                dbCompanyDetails.CardoneStatus = company.Element("CardoneStatus").Value;
                dbCompanyDetails.CardoneContractNo = GetInt(company.Element("CardoneContractNo"));
                dbCompanyDetails.CardoneContractStatus = company.Element("CardoneContractStatus").Value;
                GetCoordinates(company.Element("Coordinates"), dbCompanyDetails);

                //GetCoordinates(company.Element("Coordinates"), dbCompany );

                listOfCompanyDetails.Add(dbCompanyDetails);
                //listOfCompanies.Add(dbCompany);
            }
            dbContext.Companies.InsertAllOnSubmit(listOfCompanies);
            dbContext.CompanyDetails.InsertAllOnSubmit(listOfCompanyDetails);
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

        private static void GetCoordinates(XElement element, Companies dbCompany)
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
        private static void GetCoordinates(XElement element, CompanyDetails dbCompany)
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

        private static bool GetBool(XElement element)
        {
            if (element != null)
            {
                bool result;
                if (bool.TryParse(element.Value, out result))
                {
                    return result;
                }
            }
            return false;
        }
        
    }
}
