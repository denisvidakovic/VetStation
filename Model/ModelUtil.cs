using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;

namespace Model
{
    public class ModelUtil
    {
        public static object _theLock = new object();

        public static void Initialize()
        {
            //Initialise ActiveRecord...
            if (!ActiveRecordStarter.IsInitialized)
            {
                lock (_theLock)
                {
                    if (!ActiveRecordStarter.IsInitialized)
                    {
                        ActiveRecordStarter.Initialize();
                    }
                }
            }
        }

        public static void Initialize(Type[] arTypes)
        {
            //Initialise ActiveRecord...
            if (!ActiveRecordStarter.IsInitialized)
            {
                lock (_theLock)
                {
                    if (!ActiveRecordStarter.IsInitialized)
                    {
                        ActiveRecordStarter.Initialize(ActiveRecordSectionHandler.Instance, arTypes);
                    }
                }
            }
        }

    }
}
