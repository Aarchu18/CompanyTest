using DataAcessLayer;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;


namespace CompanyWebApi.Controllers
{
    public class tblPortfolioDetailsController : ApiController
    {
        private CompanyEntities db = new CompanyEntities();

        // GET: api/tblPortfolioDetails
           public IQueryable<tblPortfolioDetail> GettblPortfolioDetails()
           {
             return DAL.GetAllPortfolioDetails();
           }

        // GET: api/tblPortfolioDetails/5
          [ResponseType(typeof(tblPortfolioDetail))]
          public IHttpActionResult GettblPortfolioDetail(int id)
          {
              tblPortfolioDetail tblPortfolioDetail = db.tblPortfolioDetails.Find(id);
              if (tblPortfolioDetail == null)
              {
                  return NotFound();
              }

                 return Ok(tblPortfolioDetail);
          }

        // PUT: api/tblPortfolioDetails/5
          [ResponseType(typeof(void))]
          public IHttpActionResult PuttblPortfolioDetail(int id, tblPortfolioDetail tblPortfolioDetail)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }

              if (id != tblPortfolioDetail.PortfolioID)
              {
                  return BadRequest();
              }

              db.Entry(tblPortfolioDetail).State = EntityState.Modified;

              try
              {
                  db.SaveChanges();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!tblPortfolioDetailExists(id))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw;
                  }
              }

              return StatusCode(HttpStatusCode.NoContent);
          }

          // POST: api/tblPortfolioDetails
          [ResponseType(typeof(tblPortfolioDetail))]
          public IHttpActionResult PosttblPortfolioDetail( tblPortfolioDetail tblPortfolioDetail1)
          {

               DAL.AddPortfolioDetails(tblPortfolioDetail1);

                 // db.tblPortfolioDetails.Add(tblPortfolioDetail1);
              
              return CreatedAtRoute("DefaultApi", new { id = tblPortfolioDetail1.CompanyID}, tblPortfolioDetail1);
            
          }

          // DELETE: api/tblPortfolioDetails/5
          [ResponseType(typeof(tblPortfolioDetail))]
          public IHttpActionResult DeletetblPortfolioDetail(int id)
          {
              tblPortfolioDetail tblPortfolioDetail = db.tblPortfolioDetails.Find(id);
              if (tblPortfolioDetail == null)
              {
                  return NotFound();
              }

              db.tblPortfolioDetails.Remove(tblPortfolioDetail);
              db.SaveChanges();

              return Ok(tblPortfolioDetail);
          }

          protected override void Dispose(bool disposing)
          {
              if (disposing)
              {
                  db.Dispose();
              }
              base.Dispose(disposing);
          }

          private bool tblPortfolioDetailExists(int id)
          {
              return db.tblPortfolioDetails.Count(e => e.PortfolioID == id) > 0;
          }
          
    }
}