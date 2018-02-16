using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHUPA_ASSIGNEMENT_1.ErrorHandlingClasses
{
    public class HandleError
    {
        public static void HandleErrors(Exception ex)
        {
            LogErrorToDatabase(ex);
        }

        private static void LogErrorToDatabase(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}