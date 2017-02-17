using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATPDL.DB
{
    internal class StoreContext
    {
        private readonly List<Action> actions = new List<Action>();
        private readonly Lazy<ATPDLContext> lazyDb = new Lazy<ATPDLContext>(() => new ATPDLContext());
        public StoreContext()
        {
        }
        public ATPDLContext Db => lazyDb.Value;
        public void AfterSubmitChanges(Action action)
        {
            actions.Add(action);
        }
        public void SubmitChanges()
        {
            Db.SaveChanges();
            DoActions();
        }
        public async Task SubmitChangesAsync()
        {
            await Db.SaveChangesAsync();
            DoActions();
        }
        private void DoActions()
        {
            foreach (var action in actions)
            {
                action.Invoke();
            }
            actions.Clear();
        }
    }
}