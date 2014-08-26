using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Mvc4NoEF.Models
{
    public sealed class DataAccessLayer
    {
        private System.Data.Common.DbCommand _dbCommand = null;
        private static DataAccessLayer _instance;

        private static Database _dalDb;

        private DataAccessLayer() { }

        public static DataAccessLayer GetInstance()
        {
            if (_instance == null)
            {
                // Entlib 6
                var factory = new DatabaseProviderFactory();
                _dalDb = factory.CreateDefault();
                _dalDb.CreateConnection();
                _instance = new DataAccessLayer();
            }
            return _instance;
        }

        public static int SaveMovie(string name, string email, string movieAbstract, int id = 0)
        {
            GetInstance();
            string spName = "pSave";
            if (id != 0)
                spName = "pUpdate";

            var dbCommand = _dalDb.GetStoredProcCommand(spName);
            if (id != 0)
                _dalDb.AddInParameter(dbCommand, "@Id", DbType.Int32, id);
            _dalDb.AddInParameter(dbCommand, "@Name", DbType.String, name);
            _dalDb.AddInParameter(dbCommand, "@Email", DbType.String, email);
            _dalDb.AddInParameter(dbCommand, "@Abstract", DbType.String, email);

            object spReturn = _dalDb.ExecuteScalar(dbCommand);
            return (int)spReturn;
        }

    }
}