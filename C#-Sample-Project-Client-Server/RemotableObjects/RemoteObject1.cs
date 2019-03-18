using System;

namespace RemotableObjects
{
    public class RemoteObject1 : MarshalByRefObject
    {
        private int callCount = 0;

        public int GetCount()
        {
            Console.WriteLine("GetCount was called.");
            callCount++;
            return callCount;
        }

        public String EchoMe(String echoEchoMe)
        {
            Console.WriteLine(echoEchoMe);
            return echoEchoMe;
        }

        protected void testProtected(bool testme)
        {
            
        }

        private void testPrivate(bool testme)
        {

        }

        internal void testInternal(bool testme)
        {

        }

    }
}
