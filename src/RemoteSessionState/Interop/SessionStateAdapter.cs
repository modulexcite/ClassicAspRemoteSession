using System.Collections;
using System.Collections.Generic;

namespace RemoteSessionState.Interop
{
    public class SessionStateAdapter : ISessionState
    {
        private readonly dynamic _session;

        public SessionStateAdapter(dynamic session)
        {
            _session = session;
        }

        public object this[string name]
        {
            get { return _session[name]; }
            set { _session[name] = value; }
        }

        public void Remove(string name)
        {
            _session.Contents.Remove(name);
        }

        public void RemoveAll()
        {
            _session.Contents.RemoveAll();
        }

        public void Abandon()
        {
            _session.Abandon();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return new CollectionEnumerator(_session);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}