using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperasyonKatmani.Helper
{
    public sealed class MvcDbHelper
    {
        private static volatile AbstractDapperRepository _repositoryInstrance;
        private static object _syncRoot = new object();

        public MvcDbHelper()
        {

        }

        public static AbstractDapperRepository Repository
        {
            get
            {
                if (_repositoryInstrance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_repositoryInstrance == null)
                            _repositoryInstrance = new DapperRepository("ConnectionName");
                    }
                }
                return _repositoryInstrance;
            }
        }




    }

}