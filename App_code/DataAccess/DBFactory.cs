/// <summary>
/// Summary description for DBFactory
/// </summary>
namespace EBilling.DataAccess
{
    public sealed class DBFactory
    {
        public static DBHelper GetHelper()
        {
            SqlHelper IdbHelper = new SqlHelper();
            return IdbHelper;
        }
    }
}

