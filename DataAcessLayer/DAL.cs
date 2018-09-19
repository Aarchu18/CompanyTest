using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DataAcessLayer
{
    public static class DAL
    {
        static CompanyEntities DbContext;
        static DAL()
        {
            DbContext = new CompanyEntities();
        }

        //GET All Company Details
        public static IQueryable<tblCompanyDetail> GetAllCompanyDetails()
        {
            return DbContext.tblCompanyDetails; 
         }

        //GET CompanyID
        public static tblCompanyDetail GetCompany(int CompanyID)
        {
            return DbContext.tblCompanyDetails.Where(p => p.CompanyID == CompanyID).FirstOrDefault();
        }


        //GET All Portfolio Details
        public static IQueryable<tblPortfolioDetail> GetAllPortfolioDetails()
        {
            return DbContext.tblPortfolioDetails;
        }

        //Add Company Details
        public static bool AddCompanyDetails(tblCompanyDetail companyDetail)
        {
            bool status;
            try
            {
                DbContext.tblCompanyDetails.Add(companyDetail);
                DbContext.SaveChanges();
                status = true;
            }
              catch (DbUpdateException ex)
           
            {
                status = false;
                throw ex;
            }
            return status;
        }

        //Add Portfolio Details
        public static bool AddPortfolioDetails(tblPortfolioDetail portfolioDetail)
        {
            bool status;
            try
            {
                DbContext.tblPortfolioDetails.Add(portfolioDetail);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        //update companyDetails
        public static bool UpdateCompanyDetails(tblCompanyDetail companyDetail)
        {
            bool status;
            try
            {
                tblCompanyDetail prodItem = DbContext.tblCompanyDetails.Where(p => p.CompanyID == companyDetail.CompanyID).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.CompanyIndex = companyDetail.CompanyIndex;
                    prodItem.CompanyName = companyDetail.CompanyName;
                    prodItem.CompanyAddress = companyDetail.CompanyAddress;
                    prodItem.CompanyEmail = companyDetail.CompanyEmail;
                    prodItem.CompanyPhoneNo = companyDetail.CompanyPhoneNo;
                    prodItem.CompanyContactPerson = companyDetail.CompanyContactPerson;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //Delete CompanyDetails

        public static bool DeleteCompanyDetails(int id)
        {
            bool status;
            try
            {
                tblCompanyDetail prodItem = DbContext.tblCompanyDetails.Where(p => p.CompanyID == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.tblCompanyDetails.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


    }
}
