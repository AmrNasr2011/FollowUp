using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FollowUp
{
    class Push_to_db
    {
        static Semaphore s = new Semaphore(1, 1, "systemsemaphore");
        static Semaphore load = new Semaphore(1, 1);//this will be used to prevent many upload to db at same time
        static Queue<dat> Mainqueue = new Queue<dat>();
        
        struct dat
        {
           public DataTable tablex;
            public string namex;
            public Dictionary<string, string> filterx;
        };
        
        
        //the main object to this class to handle application request to database in parallel processing format
        //without reduce this application performance
        //so all function of this class should be run in parallel thread separated from main application thread
        /// <summary>
        /// this function will take datatable as (database source) and string as (required database command)
        /// and push them to queue to then another function here that work infinitally will handle it
        /// here i will add in temp queue to ensure no read write operation happened and here i will any 
        /// copy could be happen to data
        /// </summary>
        public static void add(DataTable table,string name, Dictionary<string,string> filter)//check if database command could added here
        {
            dat x;
            x.tablex = table;
            x.namex = name;
            x.filterx = filter;
            s.WaitOne();
            Mainqueue.Enqueue(x);
            s.Release();
            Thread thr = new Thread(upload);
            thr.Start();
           
        }
      
        static void upload()
        {
            int i = 5;
            dat data;
            s.WaitOne();
            data = Mainqueue.Dequeue();
            s.Release();
            //upload to database
            load.WaitOne();
            AccessDB a = new AccessDB();
            while (!a.Upload_table(data.tablex, data.namex, data.filterx) && i>1)//in case of error this sould run 4 times then exit
            {
                i--;
                Thread.Sleep(100);
            }
            
            load.Release();
        }

    }
}
