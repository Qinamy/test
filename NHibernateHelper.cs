using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using Fuli.Entity.Domain;
using Fuli.Tool.Log;

namespace Fuli.DAL.Common
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            try
            {
                return SessionFactory.OpenSession();
            }
            catch (Exception e)
            {
                LogHelper.GetInstance().WriteMessage("打开数据库失败！"+e.Message);
                return null;
            }
           
        }

        public static IStatelessSession OpenStatelessSession()
        {
            try
            {
                return SessionFactory.OpenStatelessSession();
            }
            catch (Exception e)
            {
                LogHelper.GetInstance().WriteMessage("打开数据库失败！" + e.Message);
                return null;
            }

        }
    }
}
