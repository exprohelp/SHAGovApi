using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Npgsql;
using SHAGovWebApi.Models;
using SHAGovWebApi.Repository;

namespace SHAGovWebApi.Controllers
{
   
    public class SHAController : ApiController
    {
        DataLayer repository = new DataLayer();
        [HttpGet]
        [Route("api/SHA/GetMemberInformationJSON")]
        public HttpResponseMessage GetMemberInformationJSON([FromBody] ipMemberKey ipapp)
        {
            if(ipapp.AuthKey == "XBKJGFPPUHBC178HJKLP984LKJGDCNMLK9087640")
            {
                dataSet ds = repository.GetMemberInformationJSON(ipapp.pmrssm_id);
                return Request.CreateResponse(HttpStatusCode.OK, ds);
            }
            else {
                dataSet ds = new dataSet();
                ds.Msg = "Authentication key is wrong";
                return Request.CreateResponse(HttpStatusCode.OK, ds);
            }
        }
        [HttpPost]
        [Route("api/SHA/ChandanTestMemberInfo")]
        public HttpResponseMessage ChandanTestMemberInfo([FromBody] ipMemberKey ipapp)
        {
            if(ipapp.AuthKey == "XBKJGFPPUHBC178HJKLP984LKJGDCNMLK9087640")
            {
                dataSet ds = repository.GetMemberInformationJSON(ipapp.pmrssm_id);
                return Request.CreateResponse(HttpStatusCode.OK, ds);
            }
            else
            {
                dataSet ds = new dataSet();
                ds.Msg = "Authentication key is wrong";
                return Request.CreateResponse(HttpStatusCode.OK, ds);
            }
        }
        [HttpPost]
        [Route("api/SHA/SyncChandanPatientData")]
        public HttpResponseMessage SyncChandanPatientData([FromBody]SyncChandanPatientData obj)
        {
            string result = repository.SyncChandanPatientData(obj);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
