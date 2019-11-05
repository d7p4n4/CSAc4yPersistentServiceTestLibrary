
using CSAc4yObjectService.Class;
using CSAc4yService.Class;
using d7p4n4.EFMethods.Class;
using d7p4n4.Final.Class;
using System;

namespace CSAc4yPersistentServiceTestLibrary
{
    public class PersistentService
    {
        public string baseName { get; set; }
        private Ac4yIdentificationBaseEntityMethods ac4YIdentificationBaseEntityMethods { get; set; }

        public PersistentService() { }

        public PersistentService(string newBaseName)
        {
            baseName = newBaseName;
            ac4YIdentificationBaseEntityMethods = new Ac4yIdentificationBaseEntityMethods(baseName);
        }
        public GetObjectResponse GetFirstByTemplate(int id)
        {
            var response = new GetObjectResponse();
            try
            {
                response.Object = (ac4YIdentificationBaseEntityMethods.findFirstById(id));
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
                ac4YIdentificationBaseEntityMethods.addNew(ac4YIdentificationBase);
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
