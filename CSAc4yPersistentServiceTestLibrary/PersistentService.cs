using CSAc4y.Class;
using CSAc4yObjectService.Class;
using CSAc4yService.Class;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAc4yPersistentServiceTestLibrary
{
    public class PersistentService
    {
        private AllContext context { get; set; }
        private Ac4yIdentificationBaseEntityMethods ac4YIdentificationBaseEntityMethods = new Ac4yIdentificationBaseEntityMethods(context);


        public GetObjectResponse GetFirstByTemplate(int id)
        {
            var response = new GetObjectResponse();
            try
            {
                response.setObject(ac4YIdentificationBaseEntityMethods.findFirstById(id));
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.Message });
            }

            return response;
        }

        public GetObjectResponse Save(Ac4yIdentificationBase ac4YIdentificationBase)
        {
            var response = new GetObjectResponse();
            try
            {
                ac4YIdentificationBaseEntityMethods.addNewAc4yIdentificationBase(ac4YIdentificationBase);
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.Message });
            }

            return response;

        }
    }
}
