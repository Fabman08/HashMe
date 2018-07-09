using System;

namespace com.prjteam.HashMe.Exc
{
    public class GenericFieldException:Exception
    {
        private readonly string message;

        public GenericFieldException(string error)
        {
            message = error;
        }

        public string CustomMessage
        {
            get
            {
                return message;
            }
        }
    }
}
