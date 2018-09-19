using DataAcessLayer;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
//using CompanyWebApi.Models;

namespace CompanyWebApi.Controllers
{
    public class tblCompanyDetailsController : ApiController
    {
        private CompanyEntities db = new CompanyEntities();
       

        // GET: api/tblCompanyDetails
         public IQueryable<tblCompanyDetail> GettblCompanyDetails()
         {
            return DAL.GetAllCompanyDetails(); 
          }

        // GET: api/tblCompanyDetails/5
         [ResponseType(typeof(tblCompanyDetail))]
          public IHttpActionResult GettblCompanyDetail(int id)
          {
              tblCompanyDetail tblCompanyDetail = DAL.GetCompany(id);
            if (tblCompanyDetail == null)
              {
                  return NotFound();
              }

              return Ok(tblCompanyDetail);
          }

          // PUT: api/tblCompanyDetails/5
          [ResponseType(typeof(void))]
          public IHttpActionResult PuttblCompanyDetail(int id, tblCompanyDetail tblCompanyDetail)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }

              if (id != tblCompanyDetail.CompanyID)
              {
                  return BadRequest();
              }

              db.Entry(tblCompanyDetail).State = EntityState.Modified;

              try
              {
                  db.SaveChanges();
              }
              catch (DbUpdateConcurrencyException ex)
              {
                  if (!tblCompanyDetailExists(id))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw ex;
                  }
              }

              return StatusCode(HttpStatusCode.NoContent);
          }

          // POST: api/tblCompanyDetails
          [ResponseType(typeof(tblCompanyDetail))]
          public IHttpActionResult PosttblCompanyDetail(tblCompanyDetail tblCompanyDetail)
          {
            
              try
              {
                   DAL.AddCompanyDetails(tblCompanyDetail);
              }
              catch (DbUpdateException ex)
              {
                 
                      throw ex;
                  
              }

              return CreatedAtRoute("DefaultApi", new { id = tblCompanyDetail.CompanyID }, tblCompanyDetail);
          }

          // DELETE: api/tblCompanyDetails/5
          [ResponseType(typeof(tblCompanyDetail))]
          public IHttpActionResult DeletetblCompanyDetail(int id)
          {
            
              tblCompanyDetail tblCompanyDetail =DAL.GetCompany(id);
              if (tblCompanyDetail == null)
              {
                  return NotFound();
              }

              DAL.DeleteCompanyDetails(id);
              

              return Ok(tblCompanyDetail);
          }

          protected override void Dispose(bool disposing)
          {
              if (disposing)
              {
                  db.Dispose();
              }
              base.Dispose(disposing);
          }

          private bool tblCompanyDetailExists(int id)
          {
              return db.tblCompanyDetails.Count(e => e.CompanyID == id) > 0;
          }
          
    }
}