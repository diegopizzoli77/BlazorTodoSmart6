using BlazorTodoSmart.Models;
using DnetIndexedDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CommonService.IndexedDB
{
    public class ActivityOffLineDB : IndexedDbDatabaseModel
    {

        private IndexedDbStore tableFieldStore => new TStore<ActivityItem>();

        private List<IndexedDbStore> stores => new List<IndexedDbStore>
        {
            tableFieldStore,
        };

        public ActivityOffLineDB()
        {
            Name = "BlazorActivityDB";
            Version = 1;
            Stores = stores;
            UseKeyGenerator = true;
        }
    }
}
