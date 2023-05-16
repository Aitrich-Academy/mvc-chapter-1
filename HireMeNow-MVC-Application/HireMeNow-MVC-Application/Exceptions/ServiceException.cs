namespace HireMeNow_MVC_Application.Exceptions
{
    [Serializable]
    public class ServiceException: Exception
    {
        public ServiceException()
        {
            
        }
        public ServiceException(string message) : base(message)
        {
            
        }
    }
}
