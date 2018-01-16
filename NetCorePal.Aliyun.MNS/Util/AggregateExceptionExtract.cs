using System;
using System.Collections.Generic;
using System.Text;

namespace NetCorePal.Aliyun.MNS.Util
{
    public class AggregateExceptionExtract
    {
        public static T Extract<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                if (ex is AggregateException)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
    }
}
